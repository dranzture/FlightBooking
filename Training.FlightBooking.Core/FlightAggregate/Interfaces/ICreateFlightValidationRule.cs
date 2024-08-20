using FluentValidation.Results;

namespace Training.FlightBooking.Core.FlightAggregate.Interfaces;

public interface ICreateFlightValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Flight flight, CancellationToken token);
}