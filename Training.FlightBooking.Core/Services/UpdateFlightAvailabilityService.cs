using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;


namespace Training.FlightBooking.Core.Services;

public class UpdateFlightAvailabilityService(IRepository<Flight> repository) : IUpdateFlightAvailabilityService
{
    

    public async Task DecreaseFlightAvailability(Guid flightId, int seats, CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(flightId, token);
        if (flight is null) throw new ArgumentException("Flight not found");

        flight.DecreaseSeatAvailability(seats);

        await repository.UpdateAsync(flight, token);
    }

    public async Task IncreaseFlightAvailability(Guid flightId, int seats, CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(flightId, token);
        if (flight is null) throw new ArgumentException("Flight not found");

        flight.IncreaseSeatAvailability(seats);

        await repository.UpdateAsync(flight, token);
    }
}