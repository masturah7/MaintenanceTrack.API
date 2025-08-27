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
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var get=_repo.GetAll();
            return Ok(get);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var getById = _repo.GetMaintenanceById(id);
            return Ok(getById);
        }

        [HttpGet("by-tracking/{trackingNumber}")]
        public IActionResult GetByTrackingNumber(string trackingNumber)
        {
            {
                var number = _repo.GetMaintenanceByTrackingNumber(trackingNumber);
                return Ok(number);
            }
        }

        
            [HttpPut("{id}")]

        public IActionResult UpdateMaintenances([FromRoute] int id, [FromBody] UpdateMaintenanceDto updateMaintenanceDto)
        {
            _repo.UpdateMaintenance(id, updateMaintenanceDto);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteMaintenance(int id) 
        {
            _repo.DeleteMaintenance(id);
            return NoContent();
        }
    }
}
