using Core.Entities;
using Core.Input;

namespace Core.Repository
{
    public interface IContatoRepository
    {
        IList<Contato> Index();

        Contato GetById(int id);

        IList<Contato> GetByDDD(int ddd);

        IList<Contato> GetByRegiao(string regiao);

        void Create(ContatoCreate input);

        void Update(ContatoUpdate input);

        void Delete(int id);
    }
}
