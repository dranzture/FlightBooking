using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;

public interface ICreateFlightService
{
    public Task<Result<Guid>> CreateFlight(CreateFlightRequest flight, CancellationToken token);
}