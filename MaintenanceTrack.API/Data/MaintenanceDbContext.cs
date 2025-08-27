using Microsoft.EntityFrameworkCore;

namespace MaintenanceTrack.API.Data
{
    public class MaintenanceDbContext : DbContext
    {
        public MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) :base(options)
        {
            
        }

        public DbSet<Maintenance> Maintenances { get; set; }    
    }
}
