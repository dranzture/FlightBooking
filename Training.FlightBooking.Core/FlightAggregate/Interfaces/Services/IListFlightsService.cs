using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IListFlightsService
{
    Task<Result<IEnumerable<FlightDto>>> ListFlights(CancellationToken token = default);
}