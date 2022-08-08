using Microsoft.EntityFrameworkCore;
using ProjectVehicles.Models;
using ProjectVehicles.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicles.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly VehicleDbContext _context;
        public CarRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<Car> createAsync(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return car;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public async Task<Car> readByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> readAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> updateAsync(Car car)
        {
            try
            {
                _context.Cars.Update(car);
                await _context.SaveChangesAsync();
                return car;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public async Task<bool> deleteAsync(int id)
        {
            try
            {
                var entity = await this.readByIdAsync(id);
                _context.Cars.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<List<Car>> SelectByColor(string color)
        {
            return await _context.Cars.Where(x => string.Equals(x.Color.ToLower(), color.ToLower())).ToListAsync();
        }
    }
}
