

using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.Extension.Services;
using Microsoft.AspNetCore.Identity;

namespace MaintenanceTrack.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddServices(builder.Configuration);

            //Indentity
            builder.Services.AddIdentityCore<APIUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;   
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
            })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<MaintenanceDbContext>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
