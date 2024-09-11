using FluentAssertions;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.ValueObjects;
using Xunit;

namespace IntegrationTests;

public class CreateFlightServiceTests(IntegrationTestFactory factory) : FlightRepositoryIntegrationTest(factory)
{
    [Fact]
    public async Task Creates_Flight_When_There_Is_No_Other_Flight()
    {
        // Arrange
        var airplane = new Airplane("Test Model", "Test Manufacturer", 10, 2020);
        var airplaneResult = await AirplaneRepository.AddAsync(airplane);

        var from = new Location("TX", "San Antonio");
        var to = new Location("TX", "Houston");
        var flight = new Flight(airplaneResult.Id, 10, DateTime.UtcNow.AddDays(1), DateTime.UtcNow, from, to);

        // Act
        var result = await FlightRepository.AddAsync(flight);

        await AirplaneRepository.SaveChangesAsync();
        await FlightRepository.SaveChangesAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBeEmpty();
    }
}