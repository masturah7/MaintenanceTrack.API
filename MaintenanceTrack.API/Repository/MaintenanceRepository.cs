using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Interface;
using MaintenanceTrack.API.Extension.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceTrack.API.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly MaintenanceDbContext _db;
        public MaintenanceRepository(MaintenanceDbContext db)
        {
            _db = db;
        }
        public async Task<CreateMaintenanceDto> Createmaintence(CreateMaintenanceDto createMaintenanceDto)
        {
            var maintenance = MaintenanceMapper.CreateDtoToMaintenanceModel(createMaintenanceDto);

            var existingModel = _db.Maintenances.FirstOrDefault(x => x.Title == maintenance.Title);

            if (existingModel != null)
            {
                throw new Exception("Title name already eist");
            }
            await _db.Maintenances.AddAsync(maintenance);
            await _db.SaveChangesAsync();
            return createMaintenanceDto;
        }

        public async void DeleteMaintenance(int id)
        {
            var maintenanceExist = await _db.Maintenances.FirstOrDefaultAsync(x => x.Id == id);
            if (maintenanceExist == null)
            {
                throw new Exception("The Id is not in the database");
            }
            _db.Maintenances.Remove(maintenanceExist);
           await _db.SaveChangesAsync();
        }

        public async Task<List<GetMaintenanceDto>> GetAll()
        {
            var getAll =await _db.Maintenances
                           .Select(m =>m.MaintenanceModelToGetDto())
                           .ToListAsync();

            return getAll;
            
        }

        public async Task<GetMaintenanceDto> GetMaintenanceById(int id)
        {
            var byId = await _db.Maintenances.FirstOrDefaultAsync(m => m.Id == id);
            if (byId == null) 
            {
                return null;
                
            }

            return byId.MaintenanceModelToGetDto();


        }

        public async Task<GetMaintenanceByTrackingNumberDto> GetMaintenanceByTrackingNumber(string requestTrackingNumber)
        {
            var trackingExist = await _db.Maintenances
                                   .FirstOrDefaultAsync(m => m.RequestTrackingNumber == requestTrackingNumber);

            if (trackingExist == null)
            {
                return null;
            }

            return trackingExist.MaintenanceEntityToGetDto();
        }


        public async void UpdateMaintenance(int id, UpdateMaintenanceDto updateMaintenanceDto)
        {
            var maintenanceExist =await _db.Maintenances.FirstOrDefaultAsync(x => x.Id == id);
            if(maintenanceExist == null)
            {
                throw new Exception("The Id is not in the database");
            }
            maintenanceExist.UpdateMaintenance(updateMaintenanceDto);
            _db.Maintenances.Update(maintenanceExist);
            await _db.SaveChangesAsync();
        }

        
    }
}
