using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightAvailabilityService
{
    public Task UpdateFlightAvailability(Guid flightId, int seats, ObserveFlightAvailability observe, CancellationToken token);
}