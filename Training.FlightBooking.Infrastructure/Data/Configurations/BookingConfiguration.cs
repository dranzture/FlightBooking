using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.IntegrationTest.Infrastructure.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.Flight)
            .WithMany()
            .HasForeignKey(e => e.FlightId);
        
        builder.HasOne(e => e.Passenger)
            .WithMany(e => e.Booking)
            .HasForeignKey(e => e.PassengerId);

        builder.Property(e => e.Status)
            .HasConversion(e => e.Value, 
                e => BookingStatus.FromValue(e));
    }
}