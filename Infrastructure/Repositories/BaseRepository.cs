using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //private readonly IConfiguration _configuration;
        //private readonly string _connectionString;

        private readonly DapperContext _context;

        public BaseRepository(DapperContext context)
        {
            _context = context;
        }

        private IDbConnection CreateConnection()
        {
            return _context.CreateConnection();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            using (var connection = CreateConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = CreateConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name}s";
                return await connection.QueryAsync<T>(query);
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            using (var connection = CreateConnection())
            {
                var query = $"INSERT INTO {typeof(T).Name}s ({string.Join(", ", GetProperties(entity))}) VALUES ({string.Join(", ", GetProperties(entity, "@"))})";
                var rowsAffected = await connection.ExecuteAsync(query, entity);
                if (rowsAffected > 0) return entity;
                else return null;
                
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using (var connection = CreateConnection())
            {
                var query = $"UPDATE {typeof(T).Name}s SET {string.Join(", ", GetProperties(entity, "=", "@"))} WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, entity);
                if (rowsAffected > 0) return true;
                else return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var connection = CreateConnection())
            {
                var query = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                if (rowsAffected > 0) return true;
                else return false;
            }
        }

        private IEnumerable<string> GetProperties(T entity, string separator = "", string prefix = "")
        {
            return typeof(T).GetProperties()
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)))
                .Select(p => $"{p.Name}{separator}{prefix}{p.Name}");
        }
    }
}
