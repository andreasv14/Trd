namespace Domain.Entities;

public class Transportation
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;

    public string Code { get; set; }

    public string Description { get; set; }

    public int? RouteId { get; set; }
    public Route? Route { get; set; }
}
