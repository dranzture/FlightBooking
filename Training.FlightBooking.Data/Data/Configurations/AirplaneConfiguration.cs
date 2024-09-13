using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.FlightBooking.Core.AirplaneAggregate;

namespace Training.FlightBooking.Data.Data.Configurations;

public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Manufacturer).HasMaxLength(30);
        builder.Property(e => e.Model).HasMaxLength(30);
    }
}