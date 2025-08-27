using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Enums;
using MaintenanceTrack.API.Extension.Services;

namespace MaintenanceTrack.API.Extension.Mapping
{
    public static class MaintenanceMapper
    {
        public static Maintenance CreateDtoToMaintenanceModel(this CreateMaintenanceDto createMaintenanceDto)
        {
            var maintenance = new Maintenance()
            {
                Title = createMaintenanceDto.Title,
                Description = createMaintenanceDto.Description,
                Category = (Category)createMaintenanceDto.Category,
                Priority = (Priority)createMaintenanceDto.Priority,
                Status = (Status)createMaintenanceDto.Status,
                RequestTrackingNumber = PrivateMethod.GenerateRequestTrackingNumber()


            };
            return maintenance;
        }


    }

   
}
