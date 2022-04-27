namespace Domain.Entities;

public class Route
{
    public int Id { get; set; }

    public string Description { get; set; }

    public ICollection<BusStopLocation> PinPointLocations { get; } = new HashSet<BusStopLocation>();
}
