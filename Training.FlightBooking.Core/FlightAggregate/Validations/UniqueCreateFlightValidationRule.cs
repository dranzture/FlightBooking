using FluentValidation.Results;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;

namespace Training.FlightBooking.Core.FlightAggregate.Validations;

public class UniqueCreateFlightValidationRule(IFlightRepository repository) : ICreateFlightValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Flight flight, CancellationToken token)
    {
        var existingFlight = await repository.ListByAirplaneIdAsync(flight.AirplaneId, token);

        var result = existingFlight.Any(e =>
            e.From.City == flight.From.City && 
            e.From.State == flight.From.State &&
            e.To.City == flight.To.City && 
            e.To.State == flight.To.State &&
            e.Departure.Date == flight.Departure.Date);

        return result
            ? new ValidationFailure(nameof(Flight), "Flight already exists.")
            : null;
    }
}