using Core.Entities;

namespace Core.Repository
{
    public interface IContatoRepository
    {
        IList<Contato> Index();

        Contato GetById(int id);

        void Create(Contato contato);

        void Update(Contato contato);

        void Delete(int id);
    }
}
