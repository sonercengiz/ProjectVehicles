using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Services.Abstract
{
    public interface ICarService
    {
        Task<Car> Create(CarVM carVM);
        Task<Car> ReadById(int id);
        Task<List<Car>> ReadAll();
        Task<Car> Update(int id, CarVM carVM);
        Task<bool> Delete(int id);
        Task<List<Car>> SelectByColor(string color);
        Task<Car> TurnTheLightsOn(int id);
        Task<Car> TurnTheLightsOff(int id);
    }
}
