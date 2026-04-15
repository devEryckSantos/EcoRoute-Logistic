using EcoRouteLogisticAPI.Domain.Entities;
using EcoRouteLogisticAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoRouteLogisticAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly EcoRouteDbContext _ecoRouteDbContext;

        public DriverController(EcoRouteDbContext ecoRouteDbContext)
        {
            _ecoRouteDbContext = ecoRouteDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> CreateDriver([FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _ecoRouteDbContext.Drivers.Add(driver);
            await _ecoRouteDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetDrivers()
        {
            var drivers = await _ecoRouteDbContext.Drivers.ToListAsync();
            return Ok(drivers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Driver>> GetDriverById (Guid id)
        {
            var driver = await _ecoRouteDbContext.Drivers.FindAsync(id);

            if (driver == null)
                return NotFound("Driver not found.");

            return Ok(driver);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDriverById(Guid id, [FromBody] Driver driver)
        {
            var driverToUpdate = await _ecoRouteDbContext.Drivers.FindAsync(id);

            if (driverToUpdate == null)
                return NotFound("Driver not found.");

            driverToUpdate.Name = driver.Name;
            driverToUpdate.VehiclePlate = driver.VehiclePlate;
            driverToUpdate.IsActive = driver.IsActive;

            await _ecoRouteDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDriverById (Guid id)
        {
            var driver = await _ecoRouteDbContext.Drivers.FindAsync(id);

            if (driver == null)
                return NotFound("Driver not found.");

            _ecoRouteDbContext.Drivers.Remove(driver);
            _ecoRouteDbContext.SaveChanges();

            return NoContent();
        }

    }
}
