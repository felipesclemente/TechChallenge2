using Core.Entities;
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

        public void Create(Contato contato)
        {
            contato.DataCriacao = DateTime.Now;
            _dbSet.Add(contato);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IList<Contato> Index() => _dbSet.ToList();

        public Contato GetById(int id) => _dbSet.FirstOrDefault(c => c.Id == id)!;

        public void Update(Contato contato)
        {
            _dbSet.Update(contato);
            _context.SaveChanges();
        }
    }
}
