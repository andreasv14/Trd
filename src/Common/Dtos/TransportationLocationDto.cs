using System;

namespace Trd.Common.Dtos;

public class TransportationLocationDto
{
    public int TransportationId { get; set; }

    public DateTime Timestamp { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
