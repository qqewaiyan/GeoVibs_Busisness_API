using DataEntity;
using GeoVibs_Busisness_API.Service.Movie;
using Microsoft.AspNetCore.Mvc;

namespace GeoVibs_Busisness_API.Controllers
{
    [Route(ApiRoutes.Movie)]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int venueId)
        {
            var param = new VenueParam() { VenueId = venueId };
            var rooms = await _service.GetAllAsync(param);
            return Ok(rooms);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById([FromQuery] IdParam param)

        {
            var room = await _service.GetByIdAsync(param);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] Movie room)
        {

            var success = await _service.SaveAsync(room);
            return Ok(success);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] IdParam param)
        {
            var success = await _service.DeleteAsync(param);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
