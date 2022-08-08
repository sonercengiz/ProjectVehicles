using Microsoft.EntityFrameworkCore;
using ProjectVehicles.Models;
using ProjectVehicles.Repositories;
using ProjectVehicles.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicles.Services
{
    public class BusRepository : IBusRepository
    {
        private readonly VehicleDbContext _context;
        public BusRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<Bus> createAsync(Bus bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task<Bus> readByIdAsync(int id)
        {
            return await _context.Buses.FindAsync(id);
        }

        public async Task<List<Bus>> readAllAsync()
        {
            return await _context.Buses.ToListAsync();
        }

        public async Task<Bus> updateAsync(Bus bus)
        {
            try
            {
                _context.Buses.Update(bus);
                await _context.SaveChangesAsync();
                return bus;
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
                _context.Buses.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<List<Bus>> SelectByColor(string color)
        {
            return await _context.Buses.Where(x => string.Equals(x.Color.ToLower(), color.ToLower())).ToListAsync();
        }
    }
}
