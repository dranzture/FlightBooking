using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneCapacityService
{
    Task<Result> UpdateCapacityAsync(UpdateAirplaneCapacityRequest req, CancellationToken token);
}