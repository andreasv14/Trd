using Application.Common.Interfaces;

namespace Application.Transportations.Commands;

public class UpdateTransportationRouteCommand : IRequest<int>
{
    public int TransportationId { get; set; }

    public int RouteId { get; set; }
}

public class UpdateTransportationRouteCommandHandler : IRequestHandler<UpdateTransportationRouteCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateTransportationRouteCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateTransportationRouteCommand request, CancellationToken cancellationToken)
    {
        var currentTransportation = await _context.Transportations.FirstOrDefaultAsync(t => t.Id == request.TransportationId, cancellationToken);
        if (currentTransportation == null)
        {
            throw new NullReferenceException($"Transportation with Id {request.TransportationId} cannot be found.");
        }

        var currentRoute = await _context.Routes.FirstOrDefaultAsync(r => r.Id == request.RouteId, cancellationToken);
        if (currentRoute == null)
        {
            throw new NullReferenceException($"Route with Id {request.RouteId} cannot be found.");
        }

        currentTransportation.Route = currentRoute;

        _context.Transportations.Update(currentTransportation);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}
