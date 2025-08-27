using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Interface;
using MaintenanceTrack.API.Extension.Mapping;

namespace MaintenanceTrack.API.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly MaintenanceDbContext _db;
        public MaintenanceRepository(MaintenanceDbContext db)
        {
            _db = db;
        }
        public CreateMaintenanceDto Createmaintence(CreateMaintenanceDto createMaintenanceDto)
        {
            var maintenance = MaintenanceMapper.CreateDtoToMaintenanceModel(createMaintenanceDto);
            _db.Maintenances.Add(maintenance);
            _db.SaveChanges();
            return createMaintenanceDto;
        }
    }
}
