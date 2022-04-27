namespace Application.UnitTests.Handlers;

public class CreatePinPointLocationCommandHandlerTests
{
    private readonly IApplicationDbContext _context;

    public CreatePinPointLocationCommandHandlerTests()
    {
        _context = DataSourceHelper.GetSetupInMemoryDbContext();

        DataSourceHelper.SeedData(_context);
    }

    [Fact]
    public async Task Handle_PinPointLocationIsValid_AddPinPointLocationIntoDataCollection()
    {
        var request = new CreateBusStopLocationCommand()
        {
            Code = "10",
            Description = "Aiolou",
            Latitude = 10,
            Longitude = 20,
        };

        var createPinPointLocationCommandHandler = new CreateBusStopLocationCommandHandler(_context);

        await createPinPointLocationCommandHandler.Handle(request, new CancellationToken());

        Assert.True(_context.PinPointLocations.Any());
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task Handle_PinPointLocationCodeIsNullOrEmpty_ThrowsValidationException(string code)
    {
        var request = new CreateBusStopLocationCommand()
        {
            Code = code,
            Description = "Aiolou",
            Latitude = 10,
            Longitude = 20,
        };

        var createPinPointLocationCommandHandler = new CreateBusStopLocationCommandHandler(_context);

        await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await createPinPointLocationCommandHandler.Handle(request, new CancellationToken());
        });
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task Handle_PinPointLocationDescriptionIsNullOrEmpty_ThrowsValidationException(string desciption)
    {
        var request = new CreateBusStopLocationCommand()
        {
            Code = "10",
            Description = desciption,
            Latitude = 10,
            Longitude = 20,
        };

        var createPinPointLocationCommandHandler = new CreateBusStopLocationCommandHandler(_context);

        await Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await createPinPointLocationCommandHandler.Handle(request, new CancellationToken());
        });
    }
}
