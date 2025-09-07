using System.ComponentModel.DataAnnotations;

namespace MaintenanceTrack.API.DTO
{
    public class APIUserDto
    {
        [Required]
        public string Firstname { get; set; }   
        [Required] public string Lastname { get;set; }

        [EmailAddress]
        [Required] public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmedPasword { get; set; }
    }
}
