using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class TimeRepository : IBaseRepository<Time>
    {
        private readonly DapperContext _context;

        public TimeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Time> GetByIdAsync(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Time WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Time>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Time>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Time";
                return await connection.QueryAsync<Time>(query);
            }
        }

        public async Task<Time> AddAsync(Time entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO Time (Id, Nome, IdadeLimite) VALUES (@Id, @Nome, @IdadeLimite)";

                var rowsAffected = await connection.ExecuteAsync(query, entity);

                if (rowsAffected > 0)
                {
                    return entity;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> UpdateAsync(Time entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE Time SET Nome = @Nome, IdadeLimite = @IdadeLimite WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, entity);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "DELETE FROM Time WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
