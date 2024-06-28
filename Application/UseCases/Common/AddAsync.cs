using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class AddAsync<T> where T : class, IBaseEntity
    {
        public static async Task<T> ExecuteAsync<T>(IBaseRepository<T> repository, T entity) where T : class, IBaseEntity
        {
            return await repository.AddAsync(entity);
        }
    }
}
