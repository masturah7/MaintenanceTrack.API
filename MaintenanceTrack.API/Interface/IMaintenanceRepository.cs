using MaintenanceTrack.API.DTO;

namespace MaintenanceTrack.API.Interface
{
    public interface IMaintenanceRepository
    {
        List<GetMaintenanceDto> GetAll();
        GetMaintenanceByTrackingNumberDto GetMaintenanceByTrackingNumber(string requestTrackingNumber);
        GetMaintenanceDto GetMaintenanceById(int id);
        CreateMaintenanceDto Createmaintence(CreateMaintenanceDto createMaintenanceDto);
        void UpdateMaintenance(int id, UpdateMaintenanceDto updateMaintenanceDto);
        void DeleteMaintenance(int id);
    }

}
