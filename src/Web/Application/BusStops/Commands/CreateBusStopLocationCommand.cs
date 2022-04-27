namespace Application.Pins.Commands;

public class CreateBusStopLocationCommand : IRequest<int>
{
    public string Code { get; set; }

    public string Description { get; set; }

    public long Latitude { get; set; }

    public long Longitude { get; set; }
}

public class CreateBusStopLocationCommandHandler : IRequestHandler<CreateBusStopLocationCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBusStopLocationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBusStopLocationCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Code))
        {
            throw new ValidationException("Code is null or empty");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ValidationException("Description is null or empty");
        }

        var newPinPointLocation = new BusStopLocation()
        {
            Code = request.Code,
            Description = request.Description,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
        };

        await _context.PinPointLocations.AddAsync(newPinPointLocation, cancellationToken);

        return await _context.SaveChangesAsync(cancellationToken);
    }
}
