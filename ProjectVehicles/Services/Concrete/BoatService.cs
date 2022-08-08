using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using ProjectVehicles.Repositories.Abstract;
using ProjectVehicles.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Services
{
    public class BoatService : IBoatService
    {
        private readonly IBoatRepository _boatRepository;
        public BoatService(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }
        public async Task<Boat> Create(BoatVM boatVM)
        {
            Boat _boat = new Boat
            {
                Color = boatVM.Color
            };

            return await _boatRepository.createAsync(_boat);
        }

        public async Task<Boat> ReadById(int id)
        {
            return await _boatRepository.readByIdAsync(id);
        }

        public async Task<List<Boat>> ReadAll()
        {
            return await _boatRepository.readAllAsync();
        }

        public async Task<Boat> Update(int id, BoatVM boatVM)
        {
            Boat _boat = await _boatRepository.readByIdAsync(id);
            if (_boat == null)
            {
                return null;
            }
            _boat.Color = (boatVM.Color != null) ? boatVM.Color : _boat.Color;
            return await _boatRepository.updateAsync(_boat);
        }

        public async Task<bool> Delete(int id)
        {
            return await _boatRepository.deleteAsync(id);
        }

        public async Task<List<Boat>> SelectByColor(string color)
        {
            return await _boatRepository.SelectByColor(color);
        }

    }
}
