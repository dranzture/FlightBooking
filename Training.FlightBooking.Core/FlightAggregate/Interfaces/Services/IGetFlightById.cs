using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;

public interface IGetFlightById
{
    Task<Result<FlightDto?>> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default);
}