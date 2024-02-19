using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightAvailabilityService
{
    public Task DecreaseFlightAvailability(Guid flightId, int seats, CancellationToken token);
    
    public Task IncreaseFlightAvailability(Guid flightId, int seats, CancellationToken token);
}