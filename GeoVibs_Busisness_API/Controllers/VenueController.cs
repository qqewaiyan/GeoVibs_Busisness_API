using DataEntity;
using GeoVibs_Busisness_API.Service.Venue;
using Microsoft.AspNetCore.Mvc;

namespace GeoVibs_Busisness_API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Venue)]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _service;
        public VenueController(IVenueService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int venueId)
        {
            var rooms = await _service.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById([FromQuery] VenueParam param)

        {
            var room = await _service.GetByIdAsync(param.VenueId);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] Venue room)
        {

            var success = await _service.SaveAsync(room);
            return Ok(success);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] VenueParam param)
        {
            var success = await _service.DeleteAsync(param.VenueId);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
