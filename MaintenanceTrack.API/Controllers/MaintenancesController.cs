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
        public async Task<IActionResult> CreateMaintenance([FromBody] CreateMaintenanceDto createMaintenanceDto )
        {
            var response = await _repo.Createmaintence(createMaintenanceDto);
            return Ok(response);    
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var get=await _repo.GetAll();
            return Ok(get);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var getById = await _repo.GetMaintenanceById(id);

            if (getById == null)
            {
                return NotFound("This Id IS NOT AVAILABLE IN THE DB CHECK AGAIN");
            }

            return Ok(getById);
        }

        [HttpGet("by-tracking/{trackingNumber}")]
        public async Task<IActionResult> GetByTrackingNumber(string trackingNumber)
        {
            {
                var number = await _repo.GetMaintenanceByTrackingNumber(trackingNumber);
                if (number == null)
                {
                    return NotFound("This TrackingNumber does not exist on the database");
                }
                return Ok(number);
            }
        }

        
            [HttpPut("{id}")]

        public async Task<IActionResult> UpdateMaintenances([FromRoute] int id, [FromBody] UpdateMaintenanceDto updateMaintenanceDto)
        {
            _repo.UpdateMaintenance(id, updateMaintenanceDto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult>  DeleteMaintenance(int id) 
        {
            _repo.DeleteMaintenance(id);
            return NoContent();
        }
    }
}
