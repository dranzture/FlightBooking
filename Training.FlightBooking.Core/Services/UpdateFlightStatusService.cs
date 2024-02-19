using Ardalis.SharedKernel;
using Microsoft.Extensions.Logging;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;

namespace Training.FlightBooking.Core.Services;

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