using System.Threading.Tasks;
using meli.Models;

namespace meli.Persistence
{
    public interface IVehicleRepository
    {
          Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
          void Add(Vehicle vehicle);
          void Remove(Vehicle vehicle);
    }
}