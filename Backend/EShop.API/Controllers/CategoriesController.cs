using EShop.Services.Abstract;
using EShop.Shared.ControllerBases;
using EShop.Shared.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryManager.AddAsync(categoryCreateDto);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            categoryUpdateDto.Id = id;
            var response = await _categoryManager.UpdateAsync(categoryUpdateDto);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            var response = await _categoryManager.HardDeleteAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var response = await _categoryManager.SoftDeleteAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/active")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _categoryManager.UpdateIsActiveAsync(id);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/menuitem")]
        public async Task<IActionResult> UpdateIsMenuItem(int id)
        {
            var response = await _categoryManager.UpdateIsMenuItemAsync(id);
            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryManager.GetAllAsync(isActive: true, isDeleted: false);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllForAdmin([FromQuery] bool? isActive = null, [FromQuery] bool? isDeleted = null)
        {
            var response = await _categoryManager.GetAllAsync(isActive, isDeleted);
            return CreateResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryManager.GetAsync(id);
            return CreateResult(response);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] string? status = null)
        {
            var response = await _categoryManager.CountAsync();
            return CreateResult(response);
        }

        [HttpGet("menuitems")]
        public async Task<IActionResult> GetMenuItems()
        {
            var response = await _categoryManager.GetMenuItemAsync();
            return CreateResult(response);
        }
    }
}
