using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Domain.Entities.Transportation> Transportations { get; set; }

    public DbSet<Route> Routes { get; set; }

    public DbSet<TransportationLocation> TransportationLocations { get; set; }

    public DbSet<BusStopLocation> PinPointLocations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
