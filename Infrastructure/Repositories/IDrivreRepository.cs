using EcoRouteLogisticAPI.Domain.Entities;

namespace EcoRouteLogisticAPI.Infrastructure.Repositories
{
    public interface IDrivreRepository
    {
        Task CreateDriverAsync(Driver driver);
        Task<List<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(Guid id);
        Task UpdateDriverAsync(Guid id, Driver driver);
        Task DeleteDriverAsync(Guid id);
    }
}
