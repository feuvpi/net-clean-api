using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class AtletaRepository : IBaseRepository<Atleta>
    {
        private readonly DapperContext _context;
        public AtletaRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<Atleta> GetByIdAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Could not create a database connection.");
                }

                var query = "SELECT * FROM Atleta WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Atleta>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Atleta>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Atleta";
                return await connection.QueryAsync<Atleta>(query);
            }
        }

        public async Task<Atleta> AddAsync(Atleta entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO Atleta (Id, Nome, Nascimento, Idade, Altura, Peso, Dominancia, Posicao) VALUES (@Id, @Nome, @Nascimento, @Idade, @Altura, @Peso, @Dominancia, @Posicao)";
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

        public async Task<bool> UpdateAsync(Atleta entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE Atleta SET Nome = @Nome, Nascimento = @Nascimento, Idade = @Idade, Altura = @Altura, Peso = @Peso, Dominancia = @Dominancia, Posicao = @Posicao WHERE Id = @Id";
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

                var query = "DELETE FROM Atleta WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }
    }
}
