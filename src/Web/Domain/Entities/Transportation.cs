using Domain.Enums;

namespace Domain.Entities;

public class Transportation
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public Region Region { get; set; }

    public int? RouteId { get; set; }
    public Route? Route { get; set; }
}
