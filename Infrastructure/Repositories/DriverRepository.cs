using EcoRouteLogisticAPI.Domain.Entities;
using EcoRouteLogisticAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoRouteLogisticAPI.Infrastructure.Repositories
{
    public class DriverRepository : IDrivreRepository
    {
        private readonly EcoRouteDbContext _ecoRouteDbContext;

        public DriverRepository(EcoRouteDbContext ecoRouteDbContext)
        {
            _ecoRouteDbContext = ecoRouteDbContext;
        }
        public async Task CreateDriverAsync(Driver driver)
        {
            await _ecoRouteDbContext.Drivers.AddAsync(driver);
            await _ecoRouteDbContext.SaveChangesAsync();
        }

        public async Task<List<Driver>> GetAllDriversAsync()
        {
            return await _ecoRouteDbContext.Drivers.ToListAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(Guid id)
        {
            var driver = await _ecoRouteDbContext.Drivers.FindAsync(id);
            
            if (driver == null)
                throw new KeyNotFoundException("Driver not found.");

            return driver;
        }

        public async Task UpdateDriverAsync(Guid id, Driver driver)
        {
            var driverToUpdate = await _ecoRouteDbContext.Drivers.FindAsync(id);

            if (driverToUpdate == null)
                throw new KeyNotFoundException("Driver not found.");

            driverToUpdate.Name = driver.Name;
            driverToUpdate.VehiclePlate = driver.VehiclePlate;
            driverToUpdate.IsActive = driver.IsActive;

            await _ecoRouteDbContext.SaveChangesAsync();

        }

        public async Task DeleteDriverAsync(Guid id)
        {
            var driver = await _ecoRouteDbContext.Drivers.FindAsync(id);

            if (driver == null)
                throw new KeyNotFoundException("Driver not found.");

            _ecoRouteDbContext.Drivers.Remove(driver);
            await _ecoRouteDbContext.SaveChangesAsync();
        }
    }
}
