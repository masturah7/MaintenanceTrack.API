using MaintenanceTrack.API.Data;
using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountsController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        public AcountsController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] APIUserDto userDto)
        {
            var result = await _authManager.Register(userDto);

            if(result.Any())
            {
                foreach (var error in result)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }
                return BadRequest(ModelState);
            }
            var userResponse = new APIUserDto() 
            { 
               Firstname = userDto.Firstname,
               Lastname = userDto.Lastname, 
               Email = userDto.Email,   

            
            };

            return Ok(userResponse);  
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authManager.Login(loginDto);

            if (!result)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { Message = "Loging successful" });
            }
               
        }

    }
}
