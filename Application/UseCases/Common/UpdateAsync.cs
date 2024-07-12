using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class UpdateAsync<T> where T : class, IBaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public UpdateAsync(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ExecuteAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
