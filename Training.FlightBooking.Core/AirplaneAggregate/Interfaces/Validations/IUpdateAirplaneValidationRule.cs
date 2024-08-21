using FluentValidation.Results;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken cancellationToken);
}