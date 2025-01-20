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

        [Fact]
        public void TabelaContato_EstaDisponivel()
        {
            //Arrange
            var sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //Act
            using var insertCommand = sqlConn.CreateCommand();
            insertCommand.CommandText = "INSERT INTO Contato VALUES ('Teste', 99, 123456789, 'teste@passou.com')";
            insertCommand.ExecuteScalar();

            using var queryCommand = sqlConn.CreateCommand();
            queryCommand.CommandText = "SELECT Email FROM CONTATO WHERE Nome = 'Teste'";
            var result = queryCommand.ExecuteScalar();
            sqlConn.Close();

            //Assert
            Assert.Equal("teste@passou.com", result);
        }
    }
}
