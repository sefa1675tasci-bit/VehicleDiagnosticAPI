using Microsoft.EntityFrameworkCore;
using VehicleDiagnosticAPI.Models;

namespace VehicleDiagnosticAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleStatus> VehicleStatuses { get; set; }
    }
}