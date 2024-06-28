using Core.Interfaces;


namespace Application.UseCases.Common
{
    public class GetAllAsync<T> where T : class, IBaseEntity
    {
        public static async Task<IEnumerable<T>> ExecuteAsync<T>(IBaseRepository<T> repository) where T : class, IBaseEntity
        {
            return await repository.GetAllAsync();
        }
    }
}
