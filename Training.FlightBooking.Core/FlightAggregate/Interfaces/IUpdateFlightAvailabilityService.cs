using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightAvailabilityService
{
    public Task UpdateFlightAvailability(Guid flightId, List<Passenger> passengers, ObserveFlightAvailability observe, CancellationToken token);
}