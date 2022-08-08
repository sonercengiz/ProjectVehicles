using Microsoft.EntityFrameworkCore;
using ProjectVehicles.Models;
using ProjectVehicles.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicles.Repositories
{
    public class BoatRepository : IBoatRepository
    {

        private readonly VehicleDbContext _context;
        public BoatRepository(VehicleDbContext context)
        {
            _context = context;
        }
        public async Task<Boat> createAsync(Boat boat)
        {
            _context.Boats.Add(boat);
            await _context.SaveChangesAsync();
            return boat;
        }

        public async Task<Boat> readByIdAsync(int id)
        {
            return await _context.Boats.FindAsync(id);
        }

        public async Task<List<Boat>> readAllAsync()
        {
            return await _context.Boats.ToListAsync();
        }

        public async Task<Boat> updateAsync(Boat boat)
        {
            try
            {
                _context.Boats.Update(boat);
                await _context.SaveChangesAsync();
                return boat;
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
                _context.Boats.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<List<Boat>> SelectByColor(string color)
        {
            return await _context.Boats.Where(x => string.Equals(x.Color.ToLower(), color.ToLower())).ToListAsync();
        }
    }
}
