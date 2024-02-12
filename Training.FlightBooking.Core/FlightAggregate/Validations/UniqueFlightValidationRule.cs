using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Specifications;

namespace Training.FlightBooking.Core.FlightAggregate.Validations;

public class UniqueFlightValidationRule(IRepository<Flight> repository) : IFlightValidationRule
{
    public async Task ValidateAsync(Flight flight, CancellationToken token)
    {
        var flightsByAirplane = new GetFlightsByAirplaneId(flight.Airplane.Id);
        var existingFlight = await repository.ListAsync(flightsByAirplane, token);
        
        if (existingFlight.Any(e => e.From == flight.From && e.Departure.Date == flight.Departure.Date))
        {
            throw new ArgumentException("Flight already exists");
        }
    }
}