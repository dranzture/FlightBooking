using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.IntegrationTest.Infrastructure.Data.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasKey(e => e.Id);
        builder.OwnsOne(e => e.To);
        builder.OwnsOne(e => e.From);
        builder.HasOne(e => e.Airplane)
            .WithOne()
            .HasForeignKey<Flight>(e => e.AirplaneId);
        
        builder.Property(e => e.Status)
            .HasConversion(e => e.Value, e => FlightStatus.FromValue(e));
    }
}