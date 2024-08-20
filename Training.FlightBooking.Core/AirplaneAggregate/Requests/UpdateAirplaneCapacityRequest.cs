namespace Training.FlightBooking.Core.AirplaneAggregate.Requests;

public class UpdateAirplaneCapacityRequest(Guid id, int capacity)
{
    public Guid Id { get; private set; } = id;
    public int Capacity { get; private set; } = capacity;
}