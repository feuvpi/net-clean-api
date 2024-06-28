using Core.Interfaces;
using Application.UseCases.Common;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public abstract class BaseService<T> where T : class, IBaseEntity
    {
        protected readonly ILogger<T> _logger;
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        // -- Add common methods or properties here
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync<T>.ExecuteAsync(_repository);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await GetByIdAsync<T>.ExecuteAsync(_repository, id);
        }

        public async Task<T> AddAsync(T entity)
        {
            return await AddAsync<T>.ExecuteAsync(_repository, entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await UpdateAsync<T>.ExecuteAsync(_repository, entity);
        }

        public async Task<bool> DeleteAsync(Guid id) => await DeleteAsync<T>.ExecuteAsync(_repository, id);

    }
}