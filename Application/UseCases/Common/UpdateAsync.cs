using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class UpdateAsync<T> where T : class, IBaseEntity
    {
        public static async Task<bool> ExecuteAsync<T>(IBaseRepository<T> repository, T entity) where T : class, IBaseEntity
        {
            return await repository.UpdateAsync(entity);
        }
    }
}
