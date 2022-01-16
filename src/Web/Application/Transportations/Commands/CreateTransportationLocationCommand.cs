using Application.Common.Interfaces;

namespace Application.Transportations.Commands;

public class CreateTransportationLocationCommand : IRequest<int>
{
    public int TransportationId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}

public class CreateTransportationLocationCommandHandler : IRequestHandler<CreateTransportationLocationCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTransportationLocationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTransportationLocationCommand request, CancellationToken cancellationToken)
    {
        var newTransportationLocation = new TransportationLocation
        {
            TransportationId = request.TransportationId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Timestamp = DateTime.Now
        };

        await _context.TransportationLocations.AddAsync(newTransportationLocation);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}
