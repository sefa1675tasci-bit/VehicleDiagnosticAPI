using Microsoft.AspNetCore.Mvc;
using VehicleDiagnosticAPI.DTOs;
using VehicleDiagnosticAPI.Services;

namespace VehicleDiagnosticAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IUserService _userService;

        public VehicleController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze(CreateVehicleStatusDto dto)
        {
            var result = await _userService.AnalyzeVehicleAsync(dto);

            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var result = _userService.GetHistory();

            return Ok(result);
        }

        [HttpGet("health")]
        public IActionResult GetHealth()
        {
            var result = _userService.GetSystemHealth();

            return Ok(result);
        }
    }
}