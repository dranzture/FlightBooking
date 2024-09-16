using FluentValidation.Results;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces.Validations;

public interface IUpdateFlightValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Flight flight, CancellationToken token);
}