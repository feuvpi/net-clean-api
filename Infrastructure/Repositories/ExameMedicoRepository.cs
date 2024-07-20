using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class ExameMedicoRepository : IBaseRepository<ExameMedico>
    {
        private readonly DapperContext _context;

        public ExameMedicoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<ExameMedico> GetByIdAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM ExameMedico WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<ExameMedico>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<ExameMedico>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM ExameMedico";
                return await connection.QueryAsync<ExameMedico>(query);
            }
        }

        public async Task<ExameMedico> AddAsync(ExameMedico entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO ExameMedico (Id, Descricao, AtletaId, Data, Observacoes, DocumentUrl) VALUES (@Id, @Descricao, @AtletaId, @Data, @Observacoes, @DocumentUrl)";


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

        public async Task<bool> UpdateAsync(ExameMedico entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE ExameMedico SET Descricao = @Descricao, AtletaId = @AtletaId, Data = @Data, Observacoes = @Observacoes, DocumentUrl = @DocumentUrl WHERE Id = @Id";

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

                var query = "DELETE FROM ExameMedico WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
