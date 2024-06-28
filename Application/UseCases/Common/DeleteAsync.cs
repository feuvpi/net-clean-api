using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class DeleteAsync<T> where T : class, IBaseEntity
    {
        public static async Task<bool> ExecuteAsync<T>(IBaseRepository<T> repository, Guid id) where T : class, IBaseEntity
        {
            return await repository.DeleteAsync(id);
        }
    }
}
