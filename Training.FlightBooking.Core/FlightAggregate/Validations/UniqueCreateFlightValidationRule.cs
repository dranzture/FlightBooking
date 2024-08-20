using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Specifications;

namespace Training.FlightBooking.Core.FlightAggregate.Validations;

public class UniqueCreateFlightValidationRule(IRepository<Flight> repository) : ICreateFlightValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Flight flight, CancellationToken token)
    {
        var flightsByAirplane = new GetFlightsByAirplaneId(flight.AirplaneId);
        var existingFlight = await repository.ListAsync(flightsByAirplane, token);

        return existingFlight.Any(e => e.From == flight.From && e.Departure.Date == flight.Departure.Date)
            ? new ValidationFailure(nameof(Flight), "Flight already exists")
            : null;
    }
}