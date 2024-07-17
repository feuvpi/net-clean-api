using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class TimeAtletaRepository : IBaseRepository<TimeAtleta>
    {
        private readonly DapperContext _context;

        public TimeAtletaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<TimeAtleta> GetByIdAsync(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Time WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<TimeAtleta>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<TimeAtleta>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Time";
                return await connection.QueryAsync<TimeAtleta>(query);
            }
        }

        public async Task<TimeAtleta> AddAsync(TimeAtleta entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO TimeAtleta (Id, TimeId, AtletaId, DataAssociacao) VALUES (@Id, @TimeId, @AtletaId, @DataAssociacao)";


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

        public async Task<bool> UpdateAsync(TimeAtleta entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE TimeAtleta SET TimeId = @TimeId, AtletaId = @AtletaId, DataAssociacao = @DataAssociacao WHERE Id = @Id";

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
