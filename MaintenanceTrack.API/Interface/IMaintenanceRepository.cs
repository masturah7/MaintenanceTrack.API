using MaintenanceTrack.API.DTO;

namespace MaintenanceTrack.API.Interface
{
    public interface IMaintenanceRepository
    {
        Task<List<GetMaintenanceDto>> GetAll();
        Task<GetMaintenanceByTrackingNumberDto >GetMaintenanceByTrackingNumber(string requestTrackingNumber);
        Task<GetMaintenanceDto> GetMaintenanceById(int id);
        Task<CreateMaintenanceDto> Createmaintence(CreateMaintenanceDto createMaintenanceDto);
        void UpdateMaintenance(int id, UpdateMaintenanceDto updateMaintenanceDto);
        void DeleteMaintenance(int id);
    }

}
