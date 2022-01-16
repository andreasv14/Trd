namespace Domain.Entities;

public class PinPointLocation
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public long Latitude { get; set; }

    public long Longitude { get; set; }
}
