using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Services.Abstract
{
    public interface IBoatService
    {
        Task<Boat> Create(BoatVM boatVM);
        Task<Boat> ReadById(int id);
        Task<List<Boat>> ReadAll();
        Task<Boat> Update(int id, BoatVM boatVM);
        Task<bool> Delete(int id);
        Task<List<Boat>> SelectByColor(string color);
    }
}
