using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.ValueObjects;
using Xunit;

namespace IntegrationTests;

public class CreateFlightRepositoryTests(IntegrationTestFactory factory) : FlightRepositoryIntegrationTest(factory)
{
    [Fact]
    public async Task CreateFlight_ShouldSucceed_WhenThereIsNoOtherFlight()
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

    [Fact]
    public async Task CreateFlight_ShouldThrowException_WhenThereIsAnotherFlight()
    {
        // Arrange
        var airplane = new Airplane("Test Model", "Test Manufacturer", 10, 2020);
        var airplaneResult = await AirplaneRepository.AddAsync(airplane);

        var from = new Location("TX", "San Antonio");
        var to = new Location("TX", "Houston");
        var flight = new Flight(airplaneResult.Id, 10, DateTime.UtcNow.AddDays(1), DateTime.UtcNow, from, to);


        var result = await FlightRepository.AddAsync(flight);

        await AirplaneRepository.SaveChangesAsync();
        await FlightRepository.SaveChangesAsync();
        
        // Act
        async Task Action() => await FlightRepository.AddAsync(result);
        
        // Assert
        await Assert.ThrowsAsync<DbUpdateException>(Action);
    }
}