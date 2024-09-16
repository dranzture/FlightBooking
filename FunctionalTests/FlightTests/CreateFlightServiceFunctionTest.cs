using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Xunit;

namespace FunctionalTests.FlightTests;

public class CreateFlightServiceTest : IClassFixture<FunctionalTestFactory>
{
    protected readonly ICreateFlightService CreateFlightService;
    protected readonly IAirplaneRepository AirplaneRepository;
    protected readonly IFlightRepository FlightRepository;

    protected CreateFlightServiceTest(FunctionalTestFactory factory)
    {
        var scope = factory.Services.CreateScope();
        CreateFlightService = scope.ServiceProvider.GetRequiredService<ICreateFlightService>();
        AirplaneRepository = scope.ServiceProvider.GetRequiredService<IAirplaneRepository>();
        FlightRepository = scope.ServiceProvider.GetRequiredService<IFlightRepository>();
    }
}