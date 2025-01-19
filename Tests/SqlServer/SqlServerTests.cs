using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Tests.SqlServer
{
    public class SqlServerTests
    {
        private readonly string _connectionString;

        public SqlServerTests()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("ConnectionString")!;
        }

        [Fact]
        public void AssertSqlServer_EstaConectado()
        {
            //Arrange
            var dbConn = new SqlConnection(_connectionString);
            dbConn.Open();
            
            //Act
            using var command = dbConn.CreateCommand();
            command.CommandText = "SELECT Nome FROM Contato WHERE Id = 1";
            var result = command.ExecuteScalar();

            //Assert
            Assert.Equal("Felipe Bolivar", result.ToString());
        }
    }
}
