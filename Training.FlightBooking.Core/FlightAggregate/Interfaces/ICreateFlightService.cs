using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface ICreateFlightService
{
    public Task<Flight> CreateFlight(Flight flight, CancellationToken token);
}