using Microsoft.Data.SqlClient;
using Xunit;

namespace Tests.SqlServer
{
    public class ConnectionTest
    {
        private readonly string connectionString = "Server=localhost;User ID=sa;Password=Password.123;TrustServerCertificate=true;Encrypt=false";

        [Fact]
        public void Application_CanConnectToDB()
        {
            //Arrange
            var sqlConn = new SqlConnection(connectionString);

            //Act
            using var command = sqlConn.CreateCommand();
            command.CommandText = "SELECT TOP 1 id FROM test";
            var result = command.ExecuteScalar();

            //Assert
            Assert.Equal("6623", result);
        }
    }
}
