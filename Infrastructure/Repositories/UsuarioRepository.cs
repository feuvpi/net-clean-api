using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IBaseRepository<Usuario>
    {
        private readonly DapperContext _context;

        public UsuarioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Usuario WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Usuario>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM Usuario";
                return await connection.QueryAsync<Usuario>(query);
            }
        }

        public async Task<Usuario> AddAsync(Usuario entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO Usuario (Id, Nome, Nascimento, Funcao, Email, Password) VALUES (@Id, @Nome, @Nascimento, @Funcao, @Email, @Password)";
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

        public async Task<bool> UpdateAsync(Usuario entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE Usuario SET Nome = @Nome, Nascimento = @Nascimento, Funcao = @Funcao, Email = @Email, Password = @Password WHERE Id = @Id";
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

                var query = "DELETE FROM Usuario WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
