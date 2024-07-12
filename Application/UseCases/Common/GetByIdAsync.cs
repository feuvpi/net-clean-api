using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class GetByIdAsync<T> where T : class, IBaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public GetByIdAsync(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> ExecuteAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
