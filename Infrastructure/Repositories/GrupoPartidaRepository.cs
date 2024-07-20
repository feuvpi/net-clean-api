using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class GrupoPartidaRepository : IBaseRepository<GrupoPartida>
    {
        private readonly DapperContext _context;

        public GrupoPartidaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<GrupoPartida> GetByIdAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM GrupoPartida WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<GrupoPartida>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<GrupoPartida>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM GrupoPartida";
                return await connection.QueryAsync<GrupoPartida>(query);
            }
        }

        public async Task<GrupoPartida> AddAsync(GrupoPartida entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO GrupoPartida (Id, Nome, Inicio, Fim, TimeId) VALUES (@Id, @Nome, @Inicio, @Fim, @TimeId)";
                var rowsAffected = await connection.ExecuteAsync(query, new { entity.Id, entity.Nome, entity.Inicio, entity.Fim, TimeId = entity.Time.Id });

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


        public async Task<bool> UpdateAsync(GrupoPartida entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE GrupoPartida SET Nome = @Nome, Inicio = @Inicio, Fim = @Fim, TimeId = @TimeId WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { entity.Nome, entity.Inicio, entity.Fim, TimeId = entity.Time.Id, entity.Id });

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

                var query = "DELETE FROM GrupoPartida WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
