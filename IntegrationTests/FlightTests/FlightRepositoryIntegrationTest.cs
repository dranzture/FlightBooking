using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Xunit;

namespace IntegrationTests.FlightTests;

public class FlightRepositoryIntegrationTest : IClassFixture<IntegrationTestFactory>
{
    protected readonly IRepository<Training.FlightBooking.Core.FlightAggregate.Flight> FlightRepository;
    protected readonly IRepository<Airplane> AirplaneRepository;

    protected FlightRepositoryIntegrationTest(IntegrationTestFactory factory)
    {
        var scope = factory.Services.CreateScope();
        FlightRepository = scope.ServiceProvider.GetRequiredService<IRepository<Training.FlightBooking.Core.FlightAggregate.Flight>>();
        AirplaneRepository = scope.ServiceProvider.GetRequiredService<IRepository<Airplane>>();
    }
}