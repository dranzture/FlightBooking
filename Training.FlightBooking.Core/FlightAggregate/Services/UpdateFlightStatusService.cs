using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class UpdateFlightStatusService(IRepository<Flight> repository)
    : IUpdateFlightStatusService
{
    public async Task UpdateFlightStatus(Guid flightId, FlightStatus status, CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(flightId, token);
        if (flight is null) throw new ArgumentException("Flight not found");

        flight.UpdateStatus(status);
        await repository.UpdateAsync(flight, token);
    }
}