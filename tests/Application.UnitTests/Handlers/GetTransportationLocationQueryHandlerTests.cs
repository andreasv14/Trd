namespace Application.UnitTests.Handlers;

public class GetTransportationLocationQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetTransportationLocationQueryHandlerTests()
    {
        _context = DataSourceHelper.GetSetupInMemoryDbContext();
        DataSourceHelper.SeedData(_context);

        _mapper = AutoMapperHelper.CreateMapper();
    }

    [Fact]
    public async Task Handle_HasMoreThanOneTransportationLocation_ReturnLatestTransportationLocation()
    {
        var request = new GetTransportationLocationQuery()
        {
            TransportationId = 1
        };

        var lastTransportationLocation = _context.TransportationLocations.LastOrDefault();

        var getTransportationLocationQueryHandler = new GetTransportationLocationQueryHandler(_context, _mapper);

        var result = await getTransportationLocationQueryHandler.Handle(request, new System.Threading.CancellationToken());

        Assert.True(result.Latitude == lastTransportationLocation.Latitude
            && result.Longitude == lastTransportationLocation.Longitude);
    }
}
