using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class NotaRepository : IBaseRepository<Nota>
    {
        private readonly DapperContext _context;

        public NotaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Time WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Nota>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Nota>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Time";
                return await connection.QueryAsync<Nota>(query);
            }
        }

        public async Task<Nota> AddAsync(Nota entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO Nota (Id, Valor, Data, Observacoes, AtletaId) VALUES (@Id, @Valor, @Data, @Observacoes, @AtletaId)";

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

        public async Task<bool> UpdateAsync(Nota entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE Nota SET Valor = @Valor, Data = @Data, Observacoes = @Observacoes, AtletaId = @AtletaId WHERE Id = @Id";

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

                var query = "DELETE FROM Nota WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
