namespace Application.Transportations.Queries;

public class GetTransportationLocationQuery : IRequest<TransportationLocationDto>
{
    public int TransportationId { get; set; }
}

public class GetTransportationLocationQueryHandler : IRequestHandler<GetTransportationLocationQuery, TransportationLocationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTransportationLocationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TransportationLocationDto> Handle(GetTransportationLocationQuery request, CancellationToken cancellationToken)
    {
        var currentTransportationLocation = await _context.TransportationLocations
            .OrderByDescending(r => r.Timestamp)
            .FirstOrDefaultAsync(l => l.TransportationId == request.TransportationId, cancellationToken);

        if (currentTransportationLocation == null)
        {
            throw new NullReferenceException();
        }

        return _mapper.Map<TransportationLocationDto>(currentTransportationLocation);
    }
}

