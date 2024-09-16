using FluentValidation.Results;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Validations;

public interface IUpdateAirplaneCapacityValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken cancellationToken);

}