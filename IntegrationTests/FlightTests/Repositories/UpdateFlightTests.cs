using FluentAssertions;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.ValueObjects;
using Xunit;

namespace IntegrationTests.FlightTests.Repositories;

public class UpdateFlightTests(IntegrationTestFactory factory) : FlightRepositoryIntegrationTest(factory)
{
    [Fact]
    public async Task UpdateFlight_ShouldSucceed_WhenFlightIsValid()
    {
        // Arrange
        var airplane = new Airplane("Test Model", "Test Manufacturer", 10, 2020);
        var airplaneResult = await AirplaneRepository.AddAsync(airplane);

        var from = new Location("TX", "San Antonio");
        var to = new Location("TX", "Houston");
        var flight = new Flight(airplaneResult.Id, 10, DateTime.UtcNow.AddDays(1), DateTime.UtcNow, from, to);

        var flightResult = await FlightRepository.AddAsync(flight);
        flightResult.UpdateStatus(FlightStatus.Delayed);

        //Act
        Func<Task> act = async () => await FlightRepository.UpdateAsync(flightResult);
        var testResult = await FlightRepository.GetByIdAsync(flightResult.Id);

        // Assert
        await act.Should().NotThrowAsync();
        testResult.Should()
            .NotBeNull()
            .And
            .BeOfType<Flight>()
            .Which
            .Status
            .Should()
            .Be(FlightStatus.Delayed);
    }
}