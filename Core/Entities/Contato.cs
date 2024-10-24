namespace Core.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public required int DDD { get; set; }
        public required int Telefone { get; set; }
        public string? Email { get; set; }
        public Regiao? Regiao { get; set; }
    }
}
