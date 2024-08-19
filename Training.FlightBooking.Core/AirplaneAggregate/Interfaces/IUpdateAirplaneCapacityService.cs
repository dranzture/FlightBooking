namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneCapacityService
{
    Task UpdateCapacityAsync(Guid id, int capacity, CancellationToken token);
}