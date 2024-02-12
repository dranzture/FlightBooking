using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.IntegrationTest.Infrastructure.Data.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Email).IsUnique();
    }
}