using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.Services;

public class UpdateFlightAvailabilityService(IRepository<Flight> repository) : IUpdateFlightAvailabilityService
{
    
    public async Task UpdateFlightAvailability(Guid flightId,int seats, ObserveFlightAvailability observe,
        CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(flightId, token);
        if (flight is null) throw new ArgumentException("Flight not found");

        flight.UpdateSeatAvailability(seats, observe);
        await repository.SaveChangesAsync(token);
    }
}