using System.Threading.Tasks;

namespace meli.Persistence
{

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}