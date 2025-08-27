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

        public void DeleteMaintenance(int id)
        {
            var maintenanceExist = _db.Maintenances.FirstOrDefault(x => x.Id == id);
            if (maintenanceExist == null)
            {
                throw new Exception("The Id is not in the database");
            }
            _db.Maintenances.Remove(maintenanceExist);
            _db.SaveChanges();
        }

        public List<GetMaintenanceDto> GetAll()
        {
            var getAll = _db.Maintenances
                           .Select(m =>m.MaintenanceModelToGetDto())
                           .ToList();

            return getAll;
            
        }

        public GetMaintenanceDto GetMaintenanceById(int id)
        {
            var byId = _db.Maintenances.FirstOrDefault(m => m.Id == id);
            if (byId == null) 
            {
                throw new Exception("This Id does not exist on the database");
            }

            return byId.MaintenanceModelToGetDto();


        }

        public GetMaintenanceByTrackingNumberDto GetMaintenanceByTrackingNumber(string requestTrackingNumber)
        {
            var trackingExist = _db.Maintenances
                                   .FirstOrDefault(m => m.RequestTrackingNumber == requestTrackingNumber);

            if (trackingExist == null)
            {
                throw new Exception("This Tracking number does not exist in the database");
            }

            return trackingExist.MaintenanceEntityToGetDto();
        }


        public void UpdateMaintenance(int id, UpdateMaintenanceDto updateMaintenanceDto)
        {
            var maintenanceExist = _db.Maintenances.FirstOrDefault(x => x.Id == id);
            if(maintenanceExist == null)
            {
                throw new Exception("The Id is not in the database");
            }
            maintenanceExist.UpdateMaintenance(updateMaintenanceDto);
            _db.Maintenances.Update(maintenanceExist);
            _db.SaveChanges();
        }

        
    }
}
