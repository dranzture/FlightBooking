namespace Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;

public interface IUpdateFlightAvailabilityService
{
    public Task DecreaseFlightAvailability(Guid flightId, int seats, CancellationToken token);
    
    public Task IncreaseFlightAvailability(Guid flightId, int seats, CancellationToken token);
}