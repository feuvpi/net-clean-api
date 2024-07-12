using Core.Interfaces;
using Application.UseCases.Common;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public abstract class BaseService<T> where T : class, IBaseEntity
    {
        protected readonly ILogger<T> _logger;
        private readonly IBaseRepository<T> _repository;
        private readonly GetAllAsync<T> _getAllUseCase;
        private readonly GetByIdAsync<T> _getByIdUseCase;
        private readonly AddAsync<T> _addUseCase;
        private readonly UpdateAsync<T> _updateUseCase;
        private readonly DeleteAsync<T> _deleteUseCase;

        public BaseService(
       IBaseRepository<T> repository,
       GetAllAsync<T> getAllUseCase,
       GetByIdAsync<T> getByIdUseCase,
       AddAsync<T> addUseCase,
       UpdateAsync<T> updateUseCase,
       DeleteAsync<T> deleteUseCase)
        {
            _repository = repository;
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _addUseCase = addUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
        }

        // -- Add common methods or properties here
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _getAllUseCase.ExecuteAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _getByIdUseCase.ExecuteAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _addUseCase.ExecuteAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await _updateUseCase.ExecuteAsync(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _deleteUseCase.ExecuteAsync(id);
        }

    }
}