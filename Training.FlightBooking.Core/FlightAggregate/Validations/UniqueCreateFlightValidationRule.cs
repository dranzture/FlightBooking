using FluentValidation.Results;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;

namespace Training.FlightBooking.Core.FlightAggregate.Validations;

public class UniqueCreateFlightValidationRule(IFlightRepository repository) : ICreateFlightValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Flight flight, CancellationToken token)
    {
        var existingFlight = await repository.ListByAirplaneIdAsync(flight.AirplaneId, token);

        return existingFlight.Any(e => e.From == flight.From && e.Departure.Date == flight.Departure.Date)
            ? new ValidationFailure(nameof(Flight), "Flight already exists")
            : null;
    }
}