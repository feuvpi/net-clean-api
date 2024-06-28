using System.Data;
namespace Core.Interfaces
{
    public interface IDatabaseContext
    {
        IDbConnection CreateConnection();
    }

}
