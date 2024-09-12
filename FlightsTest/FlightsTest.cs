using FluentAssertions;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.ValueObjects;

namespace FlightsTest;

public class FlightsTest
{
    [Fact]
    public void UpdateArrivalDateTime_ShouldSucceed_WhenArrivalTimeIsAfterDepartureTime()
    {
        // Arrange
        var flight = new Flight(Guid.NewGuid(),
            10,
            DateTime.Now.AddDays(3),
            DateTime.Now,
            new Location("TX", "San Antonio"),
            new Location("TX", "Houston"));

        // Act
        flight.UpdateArrivalDateTime(DateTime.Now.AddDays(2));

        // Assert
        flight.Arrival.Should().Be(DateTime.Now.AddDays(2));
    }

    [Fact]
    public void UpdateArrivalDateTime_ShouldNotSucceed_WhenArrivalTimeIsBeforeDepartureTime()
    {
        // Arrange
        var flight = new Flight(Guid.NewGuid(),
            10,
            DateTime.Now.AddDays(3),
            DateTime.Now,
            new Location("TX", "San Antonio"),
            new Location("TX", "Houston"));

        // Act && Assert 
        Assert.Throws<ArgumentException>(() => flight.UpdateArrivalDateTime(DateTime.Now.AddDays(2)));
    }
}