using EcoRouteLogisticAPI.Domain.ValueObjects;

namespace EcoRouteLogisticAPI.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string? TranckingCode { get; set; }
        public string? CustomerName { get; set; }
        public Address? DeliveryAdress { get; set; }
        public Coordinate? LastLocation { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? DriverId { get; set; }

        public Driver? Driver { get; set; }

        public ICollection<DeliveryHistory> DeliveryHistories { get; set; } = new List<DeliveryHistory>();
    }
}
