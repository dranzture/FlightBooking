using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.Services;
using Training.FlightBooking.Core.ValueObjects;

namespace CreateBookingServiceTests;

public class CreateFlightServiceTests(FunctionalTestFactory factory) : BaseServiceTest(factory)
{
    [Fact]
    public async Task Creates_Flight_When_There_Is_No_Other_Flight()
    {
        var service = new CreateFlightService(_flightRepository, _flightValidationRules);
        var newFlight = new Flight(new Airplane("TestModel", "TestManufacturer", 100, 2023), DateTime.Today,
            DateTime.Now, new Location("Texas", "San Antonio"), new Location("California", "Sacremento"));
        
        await service.CreateFlight(newFlight, CancellationToken.None);
    }
    
}