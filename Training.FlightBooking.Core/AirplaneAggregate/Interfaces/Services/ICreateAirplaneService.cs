using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface ICreateAirplaneService
{
    Task<Result<Guid>> CreateAirplaneAsync(CreateAirplaneRequest airplane, CancellationToken cancellationToken);
}