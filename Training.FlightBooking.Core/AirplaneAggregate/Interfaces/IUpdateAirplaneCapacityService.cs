namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneCapacityService
{
    Task UpdateCapacity(Guid id, int capacity, CancellationToken token);
}