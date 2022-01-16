using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Transportation> Transportations { get; set; }

    public DbSet<Route> Routes { get; set; }

    public DbSet<TransportationLocation> TransportationLocations { get; set; }

    public DbSet<PinPointLocation> PinPointLocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransportationLocation>(x => x.Property(p => p.TransportationId).IsRequired());

        //modelBuilder.Entity<Models.Transportation>(transportation =>
        //    transportation.HasOne<Route>().WithOne(r => r.Transportation)
        //    .HasForeignKey<Models.Transportation>(r => r.RouteId).OnDelete(DeleteBehavior.SetNull));

        //modelBuilder.Entity<Route>(route =>
        // route.HasMany<PinPointLocation>()
        //    .WithOne(pinLocation => pinLocation.Route)
        //    .HasForeignKey(pinLocation => pinLocation.RouteId)
        //    .OnDelete(DeleteBehavior.SetNull));

        base.OnModelCreating(modelBuilder);
    }
}
