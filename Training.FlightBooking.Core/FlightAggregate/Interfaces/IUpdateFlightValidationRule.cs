using FluentValidation.Results;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface IUpdateFlightValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Flight flight, CancellationToken token);
}