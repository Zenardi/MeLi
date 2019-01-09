using System.Threading.Tasks;

namespace meli.Core
{

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}