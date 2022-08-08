using ProjectVehicles.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Repositories.Abstract
{
    public interface IBoatRepository
    {
        Task<Boat> createAsync(Boat boat);
        Task<Boat> readByIdAsync(int id);
        Task<List<Boat>> readAllAsync();
        Task<Boat> updateAsync(Boat boat);
        Task<bool> deleteAsync(int id);
        Task<List<Boat>> SelectByColor(string color);
    }
}
