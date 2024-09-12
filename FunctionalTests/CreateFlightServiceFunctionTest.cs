using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Xunit;

namespace FunctionalTests;

public class CreateFlightServiceTest : IClassFixture<FunctionalTestFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ICreateFlightService CreateFlightService;
    protected readonly IRepository<Airplane> AirplaneRepository;

    protected CreateFlightServiceTest(FunctionalTestFactory factory)
    {
        _scope  = factory.Services.CreateScope();
        CreateFlightService = _scope.ServiceProvider.GetRequiredService<ICreateFlightService>();
        AirplaneRepository = _scope.ServiceProvider.GetRequiredService<IRepository<Airplane>>();
    }

    
}