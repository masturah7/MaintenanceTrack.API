using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.Interface;
using MaintenanceTrack.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceTrack.API.Extension.Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            service.AddScoped<IAuthManager,AuthManager>();
            var ConnectionString = configuration.GetConnectionString("MaintenanceConnectionString");
            service.AddDbContext<MaintenanceDbContext>(Options => Options.UseSqlServer(ConnectionString));

        }

    }
}
