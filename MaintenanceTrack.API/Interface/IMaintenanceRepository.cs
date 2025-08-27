using MaintenanceTrack.API.DTO;

namespace MaintenanceTrack.API.Interface
{
    public interface IMaintenanceRepository
    {
        CreateMaintenanceDto Createmaintence(CreateMaintenanceDto createMaintenanceDto);
    }
}
