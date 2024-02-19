using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.Shared;
using Training.IntegrationTest.Infrastructure.Interfaces;

namespace Training.IntegrationTest.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options,
        IDomainEventDispatcher? dispatcher)
    : DbContext(options)
{
    public DbSet<Booking> Bookings => Set<Booking>();
    
    public DbSet<Flight> Flights => Set<Flight>();
    
    public DbSet<Airplane> Airplanes => Set<Airplane>();
    
    public DbSet<Passenger> Passengers => Set<Passenger>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        
        var entitiesWithEvents = ChangeTracker.Entries<EntityBase<Guid>>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();
        
        // ignore events if no dispatcher provided
        if (dispatcher == null) return result;

        // dispatch events only if save was successful
        await dispatcher.DispatchAndClearEvents(entitiesWithEvents);
        
        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}