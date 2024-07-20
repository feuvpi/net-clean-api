using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class PartidaRepository : IBaseRepository<Partida>
    {
        private readonly DapperContext _context;

        public PartidaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Partida> GetByIdAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Partida WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Partida>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Partida>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Partida";
                return await connection.QueryAsync<Partida>(query);
            }
        }

        public async Task<Partida> AddAsync(Partida entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO Partida (Id, TimeId, GrupoPartidaId, TimeAdversario, DataHorario, Local, GolsAFavor, GolsContra) VALUES (@Id, @TimeId, @GrupoPartidaId, @TimeAdversario, @DataHorario, @Local, @GolsAFavor, @GolsContra)";
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

        public async Task<bool> UpdateAsync(Partida entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE Partida SET TimeId = @TimeId, GrupoPartidaId = @GrupoPartidaId, TimeAdversario = @TimeAdversario, DataHorario = @DataHorario, Local = @Local, GolsAFavor = @GolsAFavor, GolsContra = @GolsContra WHERE Id = @Id";
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

                var query = "DELETE FROM Partida WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
