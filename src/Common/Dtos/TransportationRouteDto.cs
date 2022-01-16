using System.Collections.Generic;

namespace Trd.Common.Dtos;

public class TransportationRouteDto
{
    public int TransportationId { get; set; }

    public List<BusStopLocationDto> PinPointLocations { get; set; } = new List<BusStopLocationDto>();
}
