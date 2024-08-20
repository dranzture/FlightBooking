using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightStatusService
{
    public Task<Result> UpdateFlightStatus(UpdateFlightRequest req, CancellationToken token);
}