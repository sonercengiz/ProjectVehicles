using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using ProjectVehicles.Repositories.Abstract;
using ProjectVehicles.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
        public async Task<Bus> Create(BusVM busVM)
        {
            Bus _bus = new Bus
            {
                Color = busVM.Color
            };

            return await _busRepository.createAsync(_bus);
        }

        public async Task<Bus> ReadById(int id)
        {
            return await _busRepository.readByIdAsync(id);
        }

        public async Task<List<Bus>> ReadAll()
        {
            return await _busRepository.readAllAsync();
        }

        public async Task<Bus> Update(int id, BusVM busVM)
        {
            Bus _bus = await _busRepository.readByIdAsync(id);
            if (_bus == null)
            {
                return null;
            }
            _bus.Color = (busVM.Color != null) ? busVM.Color : _bus.Color;
            return await _busRepository.updateAsync(_bus);
        }

        public async Task<bool> Delete(int id)
        {
            return await _busRepository.deleteAsync(id);
        }

        public async Task<List<Bus>> SelectByColor(string color)
        {
            return await _busRepository.SelectByColor(color);
        }
    }
}
