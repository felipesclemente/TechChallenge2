using Microsoft.Data.SqlClient;
using Xunit;

namespace Tests.SqlServer
{
    public class DatabaseTests
    {
        private readonly string connectionString = "Server=localhost;User ID=sa;Password=Password.1234;TrustServerCertificate=true;Encrypt=false";

        [Fact]
        public void MigrationEf_FoiAplicado()
        {
            //Arrange
            var sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //Act
            using var command = sqlConn.CreateCommand();
            command.CommandText = "SELECT Regiao FROM Regioes WHERE DDD = 11";
            var result = command.ExecuteScalar();
            sqlConn.Close();

            //Assert
            Assert.Equal("Sudeste", result);
        }
    }
}
