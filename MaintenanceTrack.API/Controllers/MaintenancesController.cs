using MaintenanceTrack.API.DTO;
using MaintenanceTrack.API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly IMaintenanceRepository _repo;
        public MaintenancesController(IMaintenanceRepository repo)
        {
            _repo = repo;   
        }

        [HttpPost]
        public IActionResult CreateMaintenance([FromBody] CreateMaintenanceDto createMaintenanceDto )
        {
            var response = _repo.Createmaintence(createMaintenanceDto);
            return Ok(response);    
        }
    }
}
