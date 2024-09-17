using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Xunit;

namespace IntegrationTests.FlightTests.Repositories;

public class FlightRepositoryIntegrationTest : IClassFixture<IntegrationTestFactory>
{
    protected readonly IRepository<Flight> FlightRepository;
    protected readonly IRepository<Airplane> AirplaneRepository;

    protected FlightRepositoryIntegrationTest(IntegrationTestFactory factory)
    {
        var scope = factory.Services.CreateScope();
        FlightRepository = scope.ServiceProvider.GetRequiredService<IRepository<Flight>>();
        AirplaneRepository = scope.ServiceProvider.GetRequiredService<IRepository<Airplane>>();
    }
}