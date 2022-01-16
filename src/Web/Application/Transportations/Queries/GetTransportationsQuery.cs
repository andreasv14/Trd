namespace Application.Transportations.Queries;

public class GetTransportationsQuery : IRequest<IEnumerable<TransportationDto>>
{
}

public class GetTransportationsQueryHandler : IRequestHandler<GetTransportationsQuery, IEnumerable<TransportationDto>>
{
    private readonly IApplicationDbContext context;
    private readonly IMapper mapper;

    public GetTransportationsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<TransportationDto>> Handle(GetTransportationsQuery request, CancellationToken cancellationToken)
    {
        var transportations = await context.Transportations.ToListAsync();

        return mapper.Map<IEnumerable<TransportationDto>>(transportations);
    }
}
