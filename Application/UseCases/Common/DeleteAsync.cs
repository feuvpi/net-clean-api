using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class DeleteAsync<T> where T : class, IBaseEntity
    {

        private readonly IBaseRepository<T> _repository;

        public DeleteAsync(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ExecuteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
