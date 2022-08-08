using Microsoft.EntityFrameworkCore;
using ProjectVehicles.Models;

namespace ProjectVehicles.Repositories
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext() { }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
