using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ProductManagement.Domain.Contracts.Repository;
using ProductManagement.Domain.Dto;
using ProductManagement.Domain.Model;
using System.Data;

namespace ProductManagement.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Postgres")
                ?? throw new InvalidOperationException("Connection string não encontrada");
        }

        public async Task<int> InsertAsync(CreateProductRequest createProduct)
        {
            const string sql = """
            INSERT INTO product (nome, url, valor)
            VALUES (@Nome, @Url, @Valor)
            RETURNING id;
            """;

            using IDbConnection connection = new NpgsqlConnection(_connectionString);

            var id = await connection.ExecuteScalarAsync<int>(sql, createProduct);
            return id;
        }
    }
}
