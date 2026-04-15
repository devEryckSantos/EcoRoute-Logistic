namespace EcoRouteLogisticAPI.Domain.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? VehiclePlate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
