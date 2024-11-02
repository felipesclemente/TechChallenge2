namespace Core.Input
{
    public class ContatoUpdate
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string? Email { get; set; }

        public ContatoUpdate(string nome, int ddd, int telefone, string? email)
        {
            Nome = nome;
            DDD = ddd;
            Telefone = telefone;
            Email = email;
        }
    }
}
