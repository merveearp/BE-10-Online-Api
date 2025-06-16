using EShop.Data.Abstract;
using EShop.Data.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EShopDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EShopDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
            }
            finally
            {
                _transaction.Dispose(); // _transaction değişkeninin işaret ettiği(referans ettiği) nesneyi öldür.
                _transaction = null!;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repository = _serviceProvider.GetRequiredService<IGenericRepository<TEntity>>();
            return repository;
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
