using FluentAssertions;
using FluentValidation;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Validations;
using Training.FlightBooking.Core.ValueObjects;
using Xunit;

namespace IntegrationTests.FlightTests.Validations;

public class UniqueCreateFlightValidationRuleTests : FlightValidationRuleIntegrationTest
{
    private readonly ICreateFlightValidationRule _rule;
    
    public UniqueCreateFlightValidationRuleTests(IntegrationTestFactory factory) : base(factory)
    {
        _rule = CreateFlightValidationRules.First(e=>e.GetType() == typeof(UniqueCreateFlightValidationRule));
    }
        
    [Fact]
    public async Task UniqueCreateFlightValidation_ShouldReturnValidationError_WhenThereIsDuplicateFlight()
    {
        // Arrange
        var airplane = new Airplane("Test Model", "Test Manufacturer", 10, 2020);
        var airplaneResult = await AirplaneRepository.AddAsync(airplane);

        var from = new Location("TX", "San Antonio");
        var to = new Location("TX", "Houston");
        var flight = new Flight(airplaneResult.Id, 10, DateTime.UtcNow.AddDays(1), DateTime.UtcNow, from, to);
        
        var flightResult = await FlightRepository.AddAsync(flight);
        
        //Act
        var result = await _rule.ValidateAsync(flightResult, default);

        // Assert
        result.Should().NotBeNull();
        result?.ErrorMessage.Should().NotBeEmpty();
        result?.Severity.Should().Be(Severity.Error);
    }
}