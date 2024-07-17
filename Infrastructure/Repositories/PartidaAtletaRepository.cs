using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using team_manegement_api.Core;

namespace Infrastructure.Repositories
{
    public class PartidaAtletaRepository : IBaseRepository<PartidaAtleta>
    {
        private readonly DapperContext _context;

        public PartidaAtletaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PartidaAtleta>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM PartidaAtleta";
                return await connection.QueryAsync<PartidaAtleta>(query);
            }
        }

        public async Task<PartidaAtleta> GetByIdAsync(Guid id)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "SELECT * FROM PartidaAtleta WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<PartidaAtleta>(query, new { Id = id });
            }
        }

        public async Task<PartidaAtleta?> AddAsync(PartidaAtleta entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "INSERT INTO PartidaAtleta (Id, AtletaId, PartidaId, Minutagem, CartoesAmarelos, CartaoVermelho, Gols) VALUES (@Id, @AtletaId, @PartidaId, @Minutagem, @CartoesAmarelos, @CartaoVermelho, @Gols)";
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

        public async Task<bool> UpdateAsync(PartidaAtleta entity)
        {
            using (var connection = _context.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Unable to create database connection.");
                }

                var query = "UPDATE PartidaAtleta SET AtletaId = @AtletaId, PartidaId = @PartidaId, Minutagem = @Minutagem, CartoesAmarelos = @CartoesAmarelos, CartaoVermelho = @CartaoVermelho, Gols = @Gols WHERE Id = @Id";
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

                var query = "DELETE FROM PartidaAtleta WHERE Id = @Id";
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

                return rowsAffected > 0;
            }
        }

    }
}
