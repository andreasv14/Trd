using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Routes.Commands;

public class CreateRouteCommand : IRequest<int>
{
    public string Description { get; set; }

    public List<PinPointLocation> PinPointLocations { get; set; } = new List<PinPointLocation>();
}

public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRouteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        var newRoute = new Route
        {
            Description = request.Description
        };

        foreach (var pinLocation in request.PinPointLocations)
        {
            newRoute.PinPointLocations.Add(new PinPointLocation { Latitude = pinLocation.Latitude, Longitude = pinLocation.Longitude });
        }

        await _context.Routes.AddAsync(newRoute);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}
