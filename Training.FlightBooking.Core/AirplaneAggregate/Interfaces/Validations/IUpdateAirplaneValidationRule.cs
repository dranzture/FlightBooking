using FluentValidation.Results;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Validations;

public interface IUpdateAirplaneValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Airplane airplaneRequest, CancellationToken cancellationToken);
}