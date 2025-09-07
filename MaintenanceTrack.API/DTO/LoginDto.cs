using System.ComponentModel.DataAnnotations;

namespace MaintenanceTrack.API.DTO
{
    public class LoginDto
    {


        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }



    }
}
