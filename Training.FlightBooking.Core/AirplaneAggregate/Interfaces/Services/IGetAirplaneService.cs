using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IGetAirplaneService
{
    Task<Result<AirplaneDto>> GetAirplaneAsync(Guid id, CancellationToken cancellationToken);
}