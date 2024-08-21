using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneService
{
    Task<Result> UpdateAirplane(UpdateAirplaneRequest erq, CancellationToken token); 
}