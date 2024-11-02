using Bogus;
using Core.Entities;
using Xunit;

namespace Tests.Infrastructure_Repository
{
    public class ContatoTests
    {
        private readonly Faker _faker;

        public ContatoTests()
        {
            _faker = new Faker();
        }

        [Fact]
        public void CreateContato_WithNomeNull_ThrowsEntityException()
        {
            //Arrange
            string nomeNull = null!;

            //Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: nomeNull, DDD: 11, telefone: 999999999, email: null));

            //Assert
            Assert.Equal("O campo de Nome não deve ser vazio ou nulo.", result.Message);
        }

        [Fact]
        public void CreateContato_WithNomeEmpty_ThrowsEntityException()
        {
            //Arrange
            string nomeEmpty = "";

            //Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: nomeEmpty, DDD: 11, telefone: 999999999, email: null));

            //Assert
            Assert.Equal("O campo de Nome não deve ser vazio ou nulo.", result.Message);
        }

        [Fact]
        public void CreateContato_WithNomeLengthAbove100_ThrowsEntityException()
        {
            //Arrange
            string nomeOverLen = _faker.Random.String2(101);

            //Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: nomeOverLen, DDD: 11, telefone: 999999999, email: null));

            //Assert
            Assert.Equal("O comprimento de Nome não deve exceder 100 caracteres.", result.Message);
        }

        [Fact]
        public void CreateContato_WithDDDZero_ThrowsEntityException()
        {
            //Arrange
            int dddZero = 0;

            //Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: "MockContato", DDD: dddZero, telefone: 999999999, email: null));

            //Assert
            Assert.Equal("O campo de DDD não deve ser zero ou nulo e deve conter 2 dígitos.", result.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void CreateContato_WithDDDUnder10_ThrowsEntityException(int testDDD)
        {
            //Arrange and Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: "MockContato", DDD: testDDD, telefone: 999999999, email: null));

            //Assert
            Assert.Equal("O campo de DDD não deve ser zero ou nulo e deve conter 2 dígitos.", result.Message);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(2000)]
        public void CreateContato_WithDDDOver99_ThrowsEntityException(int testDDD)
        {            
            //Arrange and Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: "MockContato", DDD: testDDD, telefone: 999999999, email: null));

            //Assert
            Assert.Equal("O campo de DDD não deve ser zero ou nulo e deve conter 2 dígitos.", result.Message);
        }

        [Fact]
        public void CreateContato_WithTelefoneZero_ThrowsEntityException()
        {
            //Arrange
            int telefoneZero = 0;

            //Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: "MockContato", DDD: 11, telefone: telefoneZero, email: null));

            //Assert
            Assert.Equal("O campo de Telefone não deve ser zero ou nulo e deve conter 1 a 9 dígitos.", result.Message);
        }

        [Fact]
        public void CreateContato_WithEmailLengthOver100_ThrowsEntityException()
        {
            //Arrange
            string emailOverLen = _faker.Random.String2(101);

            //Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: "MockContato", DDD: 11, telefone: 999999999, email: emailOverLen));

            //Assert
            Assert.Equal("O comprimento de Email não deve exceder 100 caracteres.", result.Message);
        }

        [Theory]
        [InlineData("email")]
        [InlineData("email@endereco")]
        [InlineData("email@endereco.")]
        public void CreateContato_WithEmailRegexFail_ThrowsEntityException(string testEmail)
        {
            //Arrange and Act
            var result = Assert.Throws<EntityException>(() => new Contato(nome: "MockContato", DDD: 11, telefone: 999999999, email: testEmail));

            //Assert
            Assert.Equal("O Email informado não é valido.", result.Message);
        }
    }
}
