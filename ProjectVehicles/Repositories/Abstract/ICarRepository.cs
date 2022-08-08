using ProjectVehicles.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Repositories.Abstract
{
    public interface ICarRepository
    {
        Task<Car> createAsync(Car car);
        Task<Car> readByIdAsync(int id);
        Task<List<Car>> readAllAsync();
        Task<Car> updateAsync(Car car);
        Task<bool> deleteAsync(int id);
        Task<List<Car>> SelectByColor(string color);
    }
}
