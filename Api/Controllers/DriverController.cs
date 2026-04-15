using EcoRouteLogisticAPI.Application.Services;
using EcoRouteLogisticAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoRouteLogisticAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDriver([FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _driverService.CreateDriverAsync(driver);
            return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriverById (Guid id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            return Ok(driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriverById(Guid id, [FromBody] Driver driver)
        {
            await _driverService.UpdateDriverAsync(id, driver);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverById (Guid id)
        {
            await _driverService.DeleteDriverAsync(id);
            return NoContent();
        }

    }
}
