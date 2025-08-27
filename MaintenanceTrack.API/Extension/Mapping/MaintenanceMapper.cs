using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Enums;
using MaintenanceTrack.API.Extension.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.CompilerServices;

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
        public static GetMaintenanceDto MaintenanceModelToGetDto(this Maintenance maintenance) 
        {
            var all = new GetMaintenanceDto();
            {
                all.Id= maintenance.Id;
                all.RequestTrackingNumber =maintenance.RequestTrackingNumber;
                all.Title= maintenance.Title;
                all.Description= maintenance.Description;
                all.Category = (Category)maintenance.Category;
                all.Priority= (Priority)maintenance.Priority;
                all.Status= (Status)maintenance.Status;


            }
            return all;
        
        }

        public static GetMaintenanceByTrackingNumberDto MaintenanceEntityToGetDto(this Maintenance maintenance)
        {
            var track = new GetMaintenanceByTrackingNumberDto()
            {
                Id = maintenance.Id,
        RequestTrackingNumber = maintenance.RequestTrackingNumber,
        Title = maintenance.Title,
        Description = maintenance.Description,
        Category = (Category)maintenance.Category,
        Priority = (Priority)maintenance.Priority,
        Status = (Status)maintenance.Status,
        CreatedAt = maintenance.CreatedAt,
        UpdatedAt = maintenance.UpdatedAt


            };
            return track;

        }

        public static void UpdateMaintenance(this Maintenance maintenance, UpdateMaintenanceDto updateMaintenanceDto)
        {
            maintenance.Title = updateMaintenanceDto.Title;
            maintenance.Description = updateMaintenanceDto.Description;
            maintenance.Category = updateMaintenanceDto.Category;
            maintenance.Priority = updateMaintenanceDto.Priority;
            maintenance.Status = updateMaintenanceDto.Status;


        }


    }

   
}
