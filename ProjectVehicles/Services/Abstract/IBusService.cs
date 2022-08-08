using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Services.Abstract
{
    public interface IBusService
    {
        Task<Bus> Create(BusVM busVM);
        Task<Bus> ReadById(int id);
        Task<List<Bus>> ReadAll();
        Task<Bus> Update(int id, BusVM busVM);
        Task<bool> Delete(int id);
        Task<List<Bus>> SelectByColor(string color);
    }
}
