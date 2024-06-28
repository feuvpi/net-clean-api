using System;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class DapperContext : IDatabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly ILogger<DapperContext> _logger;

        public DapperContext(IConfiguration configuration, ILogger<DapperContext> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            try
            {
                var connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                // Log the error message
                _logger.LogError(ex, "An error occurred while connecting to the database.");

                // Throw a new exception with a user-friendly message
                throw new Exception("An error occurred while connecting to the database.");
            }
        }
    }
}
