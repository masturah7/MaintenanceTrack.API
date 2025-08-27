using MaintenanceTrack.API.Enums;

namespace MaintenanceTrack.API.DTO
{
    public class UpdateMaintenanceDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
