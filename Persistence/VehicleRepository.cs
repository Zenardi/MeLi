using System.Threading.Tasks;
using meli.Models;
using Microsoft.EntityFrameworkCore;

namespace meli.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MeliDbContext context;
        public VehicleRepository(MeliDbContext context)
        {
            this.context = context;

        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles
                            .Include(vf => vf.Features)
                                .ThenInclude(vf => vf.Feature)
                            .Include(vf => vf.Model)
                                .ThenInclude(m => m.Maker)
                            .SingleOrDefaultAsync(v1 => v1.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }
    }
}