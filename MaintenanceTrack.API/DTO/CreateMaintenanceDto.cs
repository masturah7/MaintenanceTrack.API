using MaintenanceTrack.API.Enums;

namespace MaintenanceTrack.API.DTO
{
    public class CreateMaintenanceDto
    {
        public string RequestTrackingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; } 
        public Priority Priority { get; set; } 
        public Status Status { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}