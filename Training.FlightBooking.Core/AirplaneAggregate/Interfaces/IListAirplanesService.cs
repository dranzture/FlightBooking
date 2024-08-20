using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IListAirplanesService
{
    Task<Result<IEnumerable<AirplaneDto>>> ListAirplanesAsync(CancellationToken cancellationToken);
}