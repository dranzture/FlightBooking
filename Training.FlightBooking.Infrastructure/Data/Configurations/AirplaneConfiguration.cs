using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.IntegrationTest.Infrastructure.Data.Configurations;

public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.HasKey(e => e.Id);
    }
}