using BusSystem.Core.Buses;
using BusSystem.Core.Places;
using BusSystem.Core.Routes;
using BusSystem.Core.SeatSettings;
using BusSystem.Core.Tickets;
using BusSystem.Core.Travels;
using BusSystem.Core.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusSystem.DataAccess;

public class BusContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Route>  Routes { get; set; }
    public DbSet<SeatSetting>  SeatSettings { get; set; }
    public DbSet<Ticket>  Tickets { get; set; }
    public DbSet<Travel>  Travels { get; set; }
    public BusContext(DbContextOptions<BusContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Route>()
            .HasOne(r => r.Origin)
            .WithMany(p => p.RoutesAsOrigin)
            .HasForeignKey(r => r.OriginId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Route>()
            .HasOne(r => r.Destination)
            .WithMany(p => p.RoutesAsDestination)
            .HasForeignKey(r => r.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}