using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightAvailabilityService
{
    public Task UpdateFlightAvailability(Guid flightId, List<Passenger> passengers, ObserveFlightAvailability observe, CancellationToken token);
}