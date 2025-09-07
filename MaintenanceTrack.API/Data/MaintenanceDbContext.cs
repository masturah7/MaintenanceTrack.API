using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceTrack.API.Data
{
    public class MaintenanceDbContext : IdentityDbContext<APIUser>
    {
        public MaintenanceDbContext(DbContextOptions<MaintenanceDbContext> options) :base(options)
        {
            
        }

        public DbSet<Maintenance> Maintenances { get; set; }    
    }
}
