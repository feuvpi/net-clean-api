using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class GetByIdAsync<T> where T : class, IBaseEntity
    {
        public static async Task<T> ExecuteAsync<T>(IBaseRepository<T> repository, Guid id) where T : class, IBaseEntity
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
