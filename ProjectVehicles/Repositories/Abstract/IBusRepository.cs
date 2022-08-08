using ProjectVehicles.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Repositories.Abstract
{
    public interface IBusRepository
    {
        Task<Bus> createAsync(Bus bus);
        Task<Bus> readByIdAsync(int id);
        Task<List<Bus>> readAllAsync();
        Task<Bus> updateAsync(Bus bus);
        Task<bool> deleteAsync(int id);
        Task<List<Bus>> SelectByColor(string color);
    }
}
