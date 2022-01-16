using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using Application.Common.Interfaces;
using Application.UnitTests.Helpers;

namespace Application.UnitTests.Handlers;

public class CreateTransportationLocationCommandHandlerTests
{
    private readonly IApplicationDbContext _context;

    public CreateTransportationLocationCommandHandlerTests()
    {
        _context = DataSourceHelper.GetSetupInMemoryDbContext();
        DataSourceHelper.SeedData(_context);
    }

    [Fact]
    public async Task Handle_TransportationLocationIsValid_AddTransportationLocationIntoDataSource()
    {
        var request = new CreateTransportationLocationCommand()
        {
            Latitude = 34.672482,
            Longitude = 33.043920,
        };

        var createTransportationLocationCommandHandler = new CreateTransportationLocationCommandHandler(_context);

        await createTransportationLocationCommandHandler.Handle(request, new System.Threading.CancellationToken());

        var lastTransportationLocation_context = await _context.TransportationLocations.LastOrDefaultAsync();

        Assert.True(request.Latitude == lastTransportationLocation_context.Latitude &&
            request.Longitude == lastTransportationLocation_context.Longitude &&
            request.TransportationId == lastTransportationLocation_context.TransportationId);
    }
}
