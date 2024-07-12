using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class GetAllAsync<T> where T : class, IBaseEntity
    {

        private readonly IBaseRepository<T> _repository;

        public GetAllAsync(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
