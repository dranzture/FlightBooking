using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface ICreateFlightService
{
    public Task<Result<Guid>> CreateFlight(CreateFlightRequest flight, CancellationToken token);
}