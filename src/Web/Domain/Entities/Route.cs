namespace Domain.Entities;

public class Route
{
    public int Id { get; set; }

    public string Description { get; set; }

    public ICollection<PinPointLocation> PinPointLocations { get; } = new HashSet<PinPointLocation>();
}
