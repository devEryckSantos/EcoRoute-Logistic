namespace EcoRouteLogisticAPI.Domain.ValueObjects
{
    public record Coordinate
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
