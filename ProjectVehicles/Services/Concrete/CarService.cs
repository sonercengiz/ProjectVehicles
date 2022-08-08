using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using ProjectVehicles.Repositories.Abstract;
using ProjectVehicles.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectVehicles.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> Create(CarVM carVM)
        {
            Car _car = new Car
            {
                Color = carVM.Color,
                Headlights = carVM.Headlights,
                Wheels = carVM.Wheels,
            };

            return await _carRepository.createAsync(_car);
        }

        public async Task<Car> ReadById(int id)
        {
            return await _carRepository.readByIdAsync(id);
        }

        public async Task<List<Car>> ReadAll()
        {
            return await _carRepository.readAllAsync();
        }

        public async Task<Car> Update(int id, CarVM carVM)
        {
            Car _car = await _carRepository.readByIdAsync(id);
            if(_car == null)
            {
                return null;
            }
            _car.Color = (carVM.Color!=null)?carVM.Color:_car.Color;
            _car.Headlights = carVM.Headlights;
            _car.Wheels = (carVM.Wheels != null) ? carVM.Wheels : _car.Wheels;
            return await _carRepository.updateAsync(_car);
        }

        public async Task<bool> Delete(int id)
        {
            return await _carRepository.deleteAsync(id);
        }

        public async Task<List<Car>> SelectByColor(string color)
        {
            return await _carRepository.SelectByColor(color);
        }

        public async Task<Car> TurnTheLightsOn(int id)
        {
            var car = await _carRepository.readByIdAsync(id);
            if (car == null)
            {
                return null;
            }
            if(car.Headlights == true)
            {
                return car;
            }
            car.Headlights = true;
            return await _carRepository.updateAsync(car);
        }
        public async Task<Car> TurnTheLightsOff(int id)
        {
            var car = await _carRepository.readByIdAsync(id);
            if (car == null)
            {
                return null;
            }
            if (car.Headlights == false)
            {
                return car;
            }
            car.Headlights = false;
            return await _carRepository.updateAsync(car);
        }
    }
}
