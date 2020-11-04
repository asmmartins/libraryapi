using Library.Domain.Shared;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Library.Repository.Shared
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string collectionName)
        {
            string sql = $"SELECT * FROM [dbo].[{collectionName.Trim()}]";

            using var connection = new SqlConnection(_configuration.GetConnectionString("LibraryDbContext"));

            return await connection.QueryAsync<T>(sql);            
        }
    }
}
