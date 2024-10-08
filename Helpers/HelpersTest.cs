using System.Text.Json;
using FluentAssertions;
using Newtonsoft.Json;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Data.Helpers;

namespace Helpers;

public class HelpersTest
{
    [Fact]
    public void Flight_Serialization_Test_Should_Succeed()
    {
        var serializedString =
            "{\"To\":{\"State\":\"TX\",\"City\":\"San Antonio\"},\"From\":{\"State\":\"CA\",\"City\":\"San Francisco\"},\"Arrival\":\"2024-02-14T03:18:58.064Z\",\"Departure\":\"2024-02-14T03:18:58.064Z\",\"Seats\":200,\"BookedSeats\":2,\"Airplane\":null,\"AirplaneId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"Status\":{\"Name\":\"OnTime\",\"Value\":0},\"Id\":\"123e3656-d448-4168-b9cb-846548986328\",\"DomainEvents\":[]}";
        var flight = JsonConvert.DeserializeObject<Flight>(serializedString, new JsonSerializerSettings
        {
            ConstructorHandling =
                ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new PrivateResolver()
        });
        
        flight.Should().NotBeNull();
        flight!.To.State.Should().Be("TX");
        flight.To.City.Should().Be("San Antonio");
        flight.From.State.Should().Be("CA");
        flight.From.City.Should().Be("San Francisco");
        flight.Arrival.Should().Be(DateTime.Parse("2024-02-14T03:18:58.064Z").ToUniversalTime());
        flight.Departure.Should().Be(DateTime.Parse("2024-02-14T03:18:58.064Z").ToUniversalTime());
        flight.Seats.Should().Be(200);
        flight.BookedSeats.Should().Be(2);
        flight.Airplane.Should().BeNull();
        flight.AirplaneId.Should().Be("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        flight.Status.Name.Should().Be("OnTime");
        flight.Status.Value.Should().Be(0);
        flight.Id.Should().Be("123e3656-d448-4168-b9cb-846548986328");
        flight.DomainEvents.Should().BeEmpty();
    }
}