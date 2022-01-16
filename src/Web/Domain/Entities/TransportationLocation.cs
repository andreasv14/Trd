namespace Domain.Entities;

public class TransportationLocation
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public int TransportationId { get; set; }
    public Transportation Transportation { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
