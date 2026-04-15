namespace EcoRouteLogisticAPI.Domain.Entities
{
    public class DeliveryHistory
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public double Latitude { get; set; }
        public double Longitute { get; set; }
        public DateTime Timestamp { get; set; }
        public string? EventDescription { get; set; }
        public Order? Order { get; set; }
    }
}
