namespace Domain.Entities;

public class BusStopLocation
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public string Code { get; set; }

    public string Description { get; set; }

    public long Latitude { get; set; }

    public long Longitude { get; set; }
}
