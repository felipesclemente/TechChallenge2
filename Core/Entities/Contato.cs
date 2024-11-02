namespace Core.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string? Email { get; set; }
        public Regioes Regiao { get; set; } = null!; //propriedade de navegação

        public Contato(string nome, int DDD, int telefone, string? email)
        {
            Nome = nome;
            this.DDD = DDD;
            Telefone = telefone;
            Email = email;
            ValidateEntity();
        }

        private void ValidateEntity()
        {
            EntityValidation.AssertStringIsNotEmptyOrNull(Nome, "O campo de Nome não deve ser vazio ou nulo.");
            EntityValidation.AssertStringIsUnderMaxLength(Nome, 100, "O comprimento de Nome não deve exceder 100 caracteres.");
            EntityValidation.AssertIntIsWithinRange(DDD, 10, 99, "O campo de DDD não deve ser zero ou nulo e deve conter 2 dígitos.");
            EntityValidation.AssertIntIsWithinRange(Telefone, 1, 999999999, "O campo de Telefone não deve ser zero ou nulo e deve conter 1 a 9 dígitos.");
            EntityValidation.AssertStringIsUnderMaxLength(Email!, 100, "O comprimento de Email não deve exceder 100 caracteres.");
            EntityValidation.AssertEmailMatchesRegex(Email!, "O Email informado não é valido.");
        }
    }
}
