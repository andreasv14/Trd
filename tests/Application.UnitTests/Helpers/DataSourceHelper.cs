namespace Application.UnitTests.Helpers;

internal class MockApplicationDbContext : ApplicationDbContext, IApplicationDbContext
{
    public MockApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}

class DataSourceHelper
{
    public static IApplicationDbContext GetSetupInMemoryDbContext()
    {
        // Setup
        var dbName = Guid.NewGuid().ToString();

        DbContextOptions<MockApplicationDbContext> options = new DbContextOptionsBuilder<MockApplicationDbContext>()
                        .UseInMemoryDatabase(databaseName: dbName).Options;

        return new MockApplicationDbContext(options);
    }

    public static void SeedData(IApplicationDbContext context)
    {
        context.Transportations.Add(new Domain.Entities.Transportation
        {
            Id = 1,
            Code = "100",
            Description = "A1-100",
            Region = Domain.Enums.Region.Limassol
        });

        context.TransportationLocations.AddRange
        (
            new TransportationLocation
            {
                Timestamp = DateTime.Now,
                Latitude = 34.672295,
                Longitude = 33.043640,
                TransportationId = 1
            },

            new TransportationLocation
            {
                Timestamp = DateTime.Now.AddSeconds(1),
                Latitude = 34.672482,
                Longitude = 33.043920,
                TransportationId = 1
            },

            new TransportationLocation
            {
                Timestamp = DateTime.Now.AddSeconds(2),
                Latitude = 34.672765,
                Longitude = 33.044354,
                TransportationId = 1
            },

            new TransportationLocation
            {
                Timestamp = DateTime.Now.AddSeconds(2),
                Latitude = 34.672934,
                Longitude = 33.044596,
                TransportationId = 1
            });

        context.SaveChangesAsync(new System.Threading.CancellationToken());
    }
}
