using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Xunit;

namespace IntegrationTests;

public class BaseFlightRepositoryTest: IClassFixture<IntegrationTestFactory>
{
    private readonly IServiceScope _scope;
    protected readonly IRepository<Flight> FlightRepository;
    protected readonly IRepository<Airplane> AirplaneRepository;

    protected BaseFlightRepositoryTest(IntegrationTestFactory factory)
    {
        _scope  = factory.Services.CreateScope();
        FlightRepository = _scope.ServiceProvider.GetRequiredService<IRepository<Flight>>();
        AirplaneRepository = _scope.ServiceProvider.GetRequiredService<IRepository<Airplane>>();
    }
}