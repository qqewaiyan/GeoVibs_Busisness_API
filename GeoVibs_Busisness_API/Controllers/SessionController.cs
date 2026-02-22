using DataEntity;
using GeoVibs_Busisness_API.Service.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoVibs_Busisness_API.Controllers
{
    [Route(ApiRoutes.Session)]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionController(ISessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] VenueParam param)
        {
            var sessions = await _service.GetAllAsync(param);
            return Ok(sessions);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetById([FromQuery] IdParam param)

        {
            var room = await _service.GetByIdAsync(param);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveAsync([FromBody] Session session)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var success = await _service.SaveAsync(session);
        //    return Ok(success);
        //}

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
