using Microsoft.Extensions.DependencyInjection;
using Training.IntegrationTest.Core.FlightAggregate;
using Training.IntegrationTest.Core.Services;
using Training.IntegrationTest.Core.ValueObjects;

namespace CreateBookingServiceTests;

public class CreateFlightServiceTests(FunctionalTestFactory factory) : BaseServiceTest(factory)
{
    [Fact]
    public async Task Creates_Flight_When_There_Is_No_Other_Flight()
    {
        var service = new CreateFlightService(_flightRepository);
        var newFlight = new Flight(new Airplane("TestModel", "TestManufacturer", 100, 2023), DateTime.Today,
            DateTime.Now, new Location("Texas", "San Antonio"), new Location("California", "Sacremento"));
        
        await service.CreateFlight(newFlight, CancellationToken.None);
    }
    
}