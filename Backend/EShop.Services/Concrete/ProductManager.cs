using AutoMapper;
using EShop.Data.Abstract;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Shared.Dtos.ProductDtos;
using EShop.Shared.Dtos.ResponseDtos;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EShop.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
            _productRepository = _unitOfWork.GetRepository<Product>();
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<ResponseDto<ProductDto>> AddAsync(ProductCreateDto productCreateDto)
        {
            try
            {
                if (productCreateDto.CategoryIds.Count == 0)
                {
                    return ResponseDto<ProductDto>.Fail("En az bir kategori seçilmelidir!", StatusCodes.Status400BadRequest);
                }
                //Katerorilerin varlığı kontrol ediliyor.
                foreach (var categoryId in productCreateDto.CategoryIds)
                {
                    var categoryExists = await _categoryRepository.ExistsAsync(x => x.Id == categoryId && x.IsActive && !x.IsDeleted);
                    if (!categoryExists)
                    {
                        return ResponseDto<ProductDto>.Fail($"{categoryId} id'li kategori bulunamadı veya pasif/silinmiş.", StatusCodes.Status404NotFound);
                    }
                }
                var product = _mapper.Map<Product>(productCreateDto);
                if (productCreateDto.Image == null)
                {
                    return ResponseDto<ProductDto>.Fail("Ürün resmi boş olamaz.", StatusCodes.Status400BadRequest);
                }
                var imageResponse = await _imageService.UploadImageAsync(productCreateDto.Image, "products");
                if (!imageResponse.IsSuccessful && imageResponse.Error != null)
                {
                    return ResponseDto<ProductDto>.Fail(imageResponse.Error, imageResponse.StatusCode);
                }
                product.ImageUrl = imageResponse.Data;
                try
                {
                    await _unitOfWork.BeginTransactionAsync();
                    await _productRepository.AddAsync(product);
                    var result = await _unitOfWork.SaveAsync();
                    if (result < 1)
                    {
                        return ResponseDto<ProductDto>.Fail("Ürün eklenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
                    }
                    product.ProductCategories =
                        [.. productCreateDto
                            .CategoryIds
                            .Select(categoryId=>new ProductCategory(product.Id,categoryId))];
                    product.UpdatedAt = DateTime.UtcNow;
                    _productRepository.Update(product);
                    result = await _unitOfWork.SaveAsync();
                    if (result < 1)
                    {
                        return ResponseDto<ProductDto>.Fail("Ürün kategorileri eklenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
                    }
                    await _unitOfWork.CommitTransactionAsync();
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }





                var response = await GetAsync(product.Id, true);
                if (!response.IsSuccessful && response.Error != null)
                {
                    return ResponseDto<ProductDto>.Fail(response.Error, response.StatusCode);
                }
                return ResponseDto<ProductDto>.Success(response.Data, StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                return ResponseDto<ProductDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<int>> CountAsync(bool? isActive = null)
        {
            try
            {
                Expression<Func<Product, bool>> predicate = x => true;
                if (isActive.HasValue)
                {
                    predicate = x => x.IsActive == isActive.Value;
                }
                var count = await _productRepository.CountAsync(predicate);
                return ResponseDto<int>.Success(count, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<int>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync
            (bool? isActive = null, bool includeCategories = false, int?
                categoryId = null, bool? isDeleted = null, bool? isHome = null)
        {
            try
            {
                // Base predicate oluşturuyoruz
                var predicate = PredicateBuilder.New<Product>(true);

                // isActive null değilse, predicate'e ekle
                if (isActive.HasValue)
                {
                    predicate = predicate.And(x => x.IsActive == isActive.Value);
                }

                // isDeleted null değilse, predicate'e ekle
                if (isDeleted.HasValue)
                {
                    predicate = predicate.And(x => x.IsDeleted == isDeleted);
                }

                if (isHome.HasValue)
                {
                    predicate = predicate.And(x => x.IsHome == isHome.Value);
                }

                // categoryId null değilse, predicate'e ekle
                if (categoryId.HasValue)
                {
                    predicate = predicate.And(x => x.ProductCategories.Any(pc => pc.CategoryId == categoryId.Value));
                }


                // Include işlemleri için lambda
                var includeList = new List<Func<IQueryable<Product>, IQueryable<Product>>>();

                if (categoryId.HasValue || includeCategories)
                {
                    includeList.Add(query => query.Include(x => x.ProductCategories));
                }

                if (includeCategories)
                {
                    includeList.Add(query => query.Include(x => x.ProductCategories).ThenInclude(x => x.Category));
                }

                // Repository'den veriyi çek
                var products = await _productRepository.GetAllAsync(
                    predicate: predicate,
                    showIsDeleted: isDeleted ?? false,
                    orderBy: x => x.OrderByDescending(y => y.CreatedAt),
                    includes: [.. includeList],
                    asExpandable: true
                );



                // Veri kontrolü
                if (!products.Any())
                {
                    return ResponseDto<IEnumerable<ProductDto>>.Fail("Hiçbir ürün bulunamadı.", StatusCodes.Status404NotFound);
                }

                // Mapping işlemi
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                Console.WriteLine($"İlk ürün: {productDtos.ToList()[0].Name}");
                return ResponseDto<IEnumerable<ProductDto>>.Success(productDtos, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<IEnumerable<ProductDto>>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<ProductDto>> GetAsync(int id, bool? includeCategories)
        {
            try
            {
                var predicate = PredicateBuilder.New<Product>(x => x.Id == id);
                var product =
                    includeCategories == null || includeCategories == false
                    ? await _productRepository.GetAsync(id)
                    : await _productRepository.GetAsync(predicate: predicate, includes: query => query.Include(x => x.ProductCategories).ThenInclude(pc => pc.Category), asExpandable: true);
                if (product == null)
                {
                    return ResponseDto<ProductDto>.Fail("Ürün bulunamadı.", StatusCodes.Status404NotFound);
                }
                if (!product.IsActive)
                {
                    return ResponseDto<ProductDto>.Fail("Ürün pasif durumda.", StatusCodes.Status400BadRequest);
                }
                var productDto = _mapper.Map<ProductDto>(product);
                return ResponseDto<ProductDto>.Success(productDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<ProductDto>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<ResponseDto<NoContent>> HardDeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetAsync(predicate: x => x.Id == id, showIsDeleted: true);
                if (product == null)
                {
                    return ResponseDto<NoContent>.Fail("Ürün bulunamadı.", StatusCodes.Status404NotFound);
                }
                _productRepository.Delete(product);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Silme işlemi sırasında bir sorun oluştu!", StatusCodes.Status500InternalServerError);
                }
                _imageService.DeleteImage(product.ImageUrl!);
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> SoftDeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetAsync(
                    predicate: x => x.Id == id,
                    showIsDeleted: true
                );
                if (product == null)
                {
                    return ResponseDto<NoContent>.Fail("Ürün bulunamadı.", StatusCodes.Status404NotFound);
                }
                product.IsDeleted = !product.IsDeleted;
                product.DeletedAt = DateTime.UtcNow;
                if (product.IsDeleted) product.IsActive = false;
                _productRepository.Update(product);
                await _unitOfWork.SaveAsync();
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            try
            {
                var product = await _productRepository.GetAsync(
                    predicate: x => x.Id == productUpdateDto.Id,
                    includes: query => query.Include(x => x.ProductCategories)
                );
                if (product == null)
                {
                    return ResponseDto<NoContent>.Fail("Ürün bulunamadı.", StatusCodes.Status404NotFound);
                }
                if (!product.IsActive)
                {
                    return ResponseDto<NoContent>.Fail("Ürün pasif durumda.", StatusCodes.Status400BadRequest);
                }
                if (productUpdateDto.CategoryIds.Count == 0)
                {
                    return ResponseDto<NoContent>.Fail("En az bir kategori seçilmelidir!", StatusCodes.Status400BadRequest);
                }
                //Katerorilerin varlığı kontrol ediliyor.
                foreach (var categoryId in productUpdateDto.CategoryIds)
                {
                    var categoryExists = await _categoryRepository.ExistsAsync(x => x.Id == categoryId && x.IsActive && !x.IsDeleted);
                    if (!categoryExists)
                    {
                        return ResponseDto<NoContent>.Fail($"{categoryId} id'li kategori bulunamadı veya pasif/silinmiş.", StatusCodes.Status404NotFound);
                    }
                }
                if (productUpdateDto.Image != null)
                {

                    var imageResponse = await _imageService.UploadImageAsync(productUpdateDto.Image, "products");
                    if (!imageResponse.IsSuccessful && imageResponse.Error != null)
                    {
                        return ResponseDto<NoContent>.Fail(imageResponse.Error, imageResponse.StatusCode);
                    }
                    //Şimdi ürünün eski resmini sileceğiz
                    _imageService.DeleteImage(product.ImageUrl!);
                    product.ImageUrl = imageResponse.Data;
                }
                _mapper.Map(productUpdateDto, product);

                try
                {
                    await _unitOfWork.BeginTransactionAsync();
                    product.ProductCategories.Clear();
                    product.ProductCategories =
                        [.. productUpdateDto
                            .CategoryIds
                            .Select(categoryId=>new ProductCategory(product.Id,categoryId))];
                    product.UpdatedAt = DateTime.UtcNow;
                    if (!product.IsActive) product.IsHome = false;
                    _productRepository.Update(product);
                    var result = await _unitOfWork.SaveAsync();
                    if (result < 1)
                    {
                        return ResponseDto<NoContent>.Fail("Ürün güncellenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
                    }
                    await _unitOfWork.CommitTransactionAsync();
                }
                catch (System.Exception)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }

                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateIsActiveAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetAsync(id);
                if (product == null)
                {
                    return ResponseDto<NoContent>.Fail("Ürün bulunamadı.", StatusCodes.Status404NotFound);
                }
                product.IsActive = !product.IsActive;
                if (!product.IsActive) product.IsHome = false;
                product.UpdatedAt = DateTime.UtcNow;
                _productRepository.Update(product);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Ürün güncellenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateIsHomeAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetAsync(id);
                if (product == null)
                {
                    return ResponseDto<NoContent>.Fail("Ürün bulunamadı.", StatusCodes.Status404NotFound);
                }
                product.IsHome = !product.IsHome;
                product.UpdatedAt = DateTime.UtcNow;
                _productRepository.Update(product);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Ürün güncellenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateIsActiveByCategoryAsync
            (int categoryId)
        {
            try
            {
                var products = await _productRepository.GetAllAsync(x => x.ProductCategories.Any(y => y.CategoryId == categoryId));
                foreach (var product in products)
                {
                    product.IsActive = !product.IsActive;
                    product.UpdatedAt = DateTime.UtcNow;
                }
                _productRepository.BatchUpdate(products);
                var result = await _unitOfWork.SaveAsync();
                if (result < 1)
                {
                    return ResponseDto<NoContent>.Fail("Ürün güncellenirken bir hata oluştu.", StatusCodes.Status500InternalServerError);
                }
                return ResponseDto<NoContent>.Success(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return ResponseDto<NoContent>.Fail(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
