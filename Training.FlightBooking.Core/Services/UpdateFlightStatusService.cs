using Ardalis.SharedKernel;
using Microsoft.Extensions.Logging;
using Training.IntegrationTest.Core.FlightAggregate;
using Training.IntegrationTest.Core.FlightAggregate.Interfaces;
using Training.IntegrationTest.Core.FlightAggregate.Specifications;

namespace Training.IntegrationTest.Core.Services;

public class UpdateFlightStatusService(IRepository<Flight> repository)
    : IUpdateFlightStatusService
{
    public async Task UpdateFlightStatus(Guid flightId, FlightStatus status, CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(flightId, token);
        if (flight is null) throw new ArgumentException("Flight not found");

        flight.UpdateStatus(status);
        await repository.SaveChangesAsync(token);
    }
}