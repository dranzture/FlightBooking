namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightStatusService
{
    public Task UpdateFlightStatus(Guid flightId, FlightStatus status, CancellationToken token);
}