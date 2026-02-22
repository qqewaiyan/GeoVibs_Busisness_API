using DataEntity;
using GeoVibs_Busisness_API.Service.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using M = DataEntity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeoVibs_Busisness_API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Auth)]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> VenueRegister(RegisterRequestParam param)
        {
            var error = await _authService.RegisterAsync(param);
            if (!string.IsNullOrWhiteSpace(error))
                return BadRequest(error);

            return Ok("Registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestParam param)
        {
            var loginResult = await _authService.LoginAsync(param);
            if (!loginResult.IsSuccess)
                return BadRequest("User not found!");

            return Ok(loginResult);
        }

        [HttpGet("secure-data")]
        [Authorize]
        public IActionResult SecureData()
        {
            return Ok("This is protected data.");
        }
    }
}
