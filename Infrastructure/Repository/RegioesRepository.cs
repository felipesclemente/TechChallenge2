using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RegioesRepository : IRegioesRepository
    {
        protected ApplicationDbContext _context;
        protected DbSet<Regioes> _dbSet;

        public RegioesRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Regioes>();
        }

        public IList<Regioes> Index() => _dbSet.ToList();
    }
}
