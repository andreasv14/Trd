namespace Application.Transportations.Queries;

public class GetTransportationRouteQuery : IRequest<TransportationRouteDto>
{
    public int TransportationId { get; set; }
}

public class GetTransportationRouteQueryHandler : IRequestHandler<GetTransportationRouteQuery, TransportationRouteDto>
{
    private readonly IApplicationDbContext context;

    public GetTransportationRouteQueryHandler(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<TransportationRouteDto> Handle(GetTransportationRouteQuery request, CancellationToken cancellationToken)
    {
        var tranportation = await context.Transportations
            .Include(x => x.Route)
            .FirstOrDefaultAsync(t => t.Id == request.TransportationId);

        if (tranportation == null)
        {
            throw new NullReferenceException($"Cannot find route for transportation with id {request.TransportationId}");
        }

        var route = await context.Routes
            .Include(x => x.PinPointLocations)
            .FirstOrDefaultAsync(r => r.Id == tranportation.Route.Id);

        if (route == null)
        {
            throw new NullReferenceException($"Cannot find route for transportation with id {request.TransportationId}");
        }

        var transportationRouteDto = new TransportationRouteDto
        {
            TransportationId = tranportation.Id
        };

        foreach (var busStopLocation in route.PinPointLocations)
        {
            transportationRouteDto.PinPointLocations.Add(new BusStopLocationDto { Latitude = busStopLocation.Latitude, Longitude = busStopLocation.Longitude });
        }

        return transportationRouteDto;
    }
}
