using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneService
{
    Task<AirplaneDto> UpdateAirplane(AirplaneDto airplane, CancellationToken token); 
}