using System.Threading.Tasks;
using meli.Core;

namespace meli.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeliDbContext context;
        public UnitOfWork(MeliDbContext context)
        {
            this.context = context;

        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}