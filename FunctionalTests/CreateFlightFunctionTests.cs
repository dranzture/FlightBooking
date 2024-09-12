using FluentAssertions;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.ValueObjects;
using Xunit;

namespace FunctionalTests;

public class CreateFlightFunctionTests(FunctionalTestFactory factory) : CreateFlightServiceTest(factory)
{
    [Fact]
    public async void CreateFlight_ShouldSucceed_WhenThereIsNoOtherFlight()
    {
        // Arrange
        var airplane = new Airplane("Test Model", "Test Manufacturer", 10, 2020);
        var airplaneResult = await AirplaneRepository.AddAsync(airplane);
        
        var createFlightRequest = new CreateFlightRequest(
            new FlightDto(
                airplaneResult.Id,
                10,
                new LocationDto("TX", "San Antonio"), 
                new LocationDto("TX", "Houston"),
                DateTime.UtcNow.AddDays(1),
                DateTime.UtcNow,
                FlightStatus.OnTime)
            {
                Id = Guid.NewGuid()
            });


        // Act
        var result = CreateFlightService.CreateFlight(createFlightRequest);

        // Assert
        result.Result.Should().NotBeNull();
        result.Result.IsSuccess.Should().BeTrue();
    }
}