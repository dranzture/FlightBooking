using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Validations;
using Training.FlightBooking.Data.Repositories;
using Xunit;

namespace IntegrationTests.FlightTests.Validations;

public class FlightValidationRuleIntegrationTest : IClassFixture<IntegrationTestFactory>
{
    protected readonly IRepository<Flight> FlightRepository;
    protected readonly IRepository<Airplane> AirplaneRepository;
    protected readonly IEnumerable<ICreateFlightValidationRule> CreateFlightValidationRules;
    protected FlightValidationRuleIntegrationTest(IntegrationTestFactory factory)
    {
        var scope = factory.Services.CreateScope();
        FlightRepository = scope.ServiceProvider.GetRequiredService<IRepository<Flight>>();
        CreateFlightValidationRules = scope.ServiceProvider.GetRequiredService<IEnumerable<ICreateFlightValidationRule>>();
        AirplaneRepository = scope.ServiceProvider.GetRequiredService<IRepository<Airplane>>();
    }
}