namespace Core.Input
{
    public class ContatoCreate
    {
        public string Nome { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string? Email { get; set; }

        public ContatoCreate(string nome, int ddd, int telefone, string? email)
        {
            Nome = nome;
            DDD = ddd;
            Telefone = telefone;
            Email = email;
        }
    }
}
