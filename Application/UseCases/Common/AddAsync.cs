using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class AddAsync<T> where T : class, IBaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public AddAsync(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> ExecuteAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }
    }
}
