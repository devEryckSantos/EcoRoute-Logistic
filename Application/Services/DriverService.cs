using EcoRouteLogisticAPI.Domain.Entities;
using EcoRouteLogisticAPI.Infrastructure.Repositories;

namespace EcoRouteLogisticAPI.Application.Services
{
    public class DriverService
    {
        private readonly IDrivreRepository _driverRepository;

        public DriverService(IDrivreRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task CreateDriverAsync(Driver driver)
        {
            await _driverRepository.CreateDriverAsync(driver);
        }

        public async Task<List<Driver>> GetAllDriversAsync()
        {
            return await _driverRepository.GetAllDriversAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(Guid id)
        {
            return await _driverRepository.GetDriverByIdAsync(id);
        }

        public async Task UpdateDriverAsync(Guid id, Driver driver)
        {
            await _driverRepository.UpdateDriverAsync(id, driver);
        }

        public async Task DeleteDriverAsync(Guid id)
        {
            await _driverRepository.DeleteDriverAsync(id);
        }
    }
}
