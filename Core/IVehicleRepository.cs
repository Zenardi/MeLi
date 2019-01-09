using System.Threading.Tasks;
using meli.Core.Models;

namespace meli.Core
{
    public interface IVehicleRepository
    {
          Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
          void Add(Vehicle vehicle);
          void Remove(Vehicle vehicle);
    }
}