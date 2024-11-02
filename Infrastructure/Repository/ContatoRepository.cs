using Core.Entities;
using Core.Input;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        protected ApplicationDbContext _context;
        protected DbSet<Contato> _dbSet;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Contato>();
        }

        public IList<Contato> Index()
        {
            var contatos = _dbSet.Include(c => c.Regiao).ToList();
            if (contatos.Count == 0)
            {
                throw new Exception("Nenhum contato foi localizado.");
            }
            return contatos;
        }

        public Contato GetById(int id) => _dbSet.Include(c => c.Regiao).FirstOrDefault(c => c.Id == id) ?? throw new Exception("Nenhum contato foi localizado para o ID informado.");

        public IList<Contato> GetByDDD(int ddd)
        {
            var contatos = _dbSet.Include(c => c.Regiao).Where(c => c.DDD == ddd).ToList();
            if (contatos.Count == 0)
            {
                throw new Exception("Nenhum contato foi localizado para o DDD informado.");
            }
            return contatos;
        }

        public IList<Contato> GetByRegiao(string regiao)
        {
            string[] regioesValidas = ["norte", "nordeste", "centro-oeste", "sudeste", "sul"];
            if (Array.IndexOf(regioesValidas, regiao.ToLower()) == -1)
            {
                throw new Exception("A região informada não é valida.");
            }

            var contatos = _dbSet.Include(c => c.Regiao).Where(c => c.Regiao.Regiao == regiao).ToList();
            if (contatos.Count == 0)
            {
                throw new Exception("Nenhum contato foi localizado para a região informada.");
            }
            return contatos;
        }

        public void Create(ContatoCreate input)
        {
            try
            {
                Contato contato = new
                (
                    nome: input.Nome,
                    DDD: input.DDD,
                    telefone: input.Telefone,
                    email: input.Email
                );
                _dbSet.Add(contato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }

        public void Update(ContatoUpdate input)
        {
            try
            {
                var contato = GetById(input.Id);
                contato.Nome = input.Nome;
                contato.DDD = input.DDD;
                contato.Telefone = input.Telefone;
                contato.Email = input.Email;
                _dbSet.Update(contato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dbSet.Remove(GetById(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }
    }
}
