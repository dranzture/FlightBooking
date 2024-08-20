using FluentValidation.Results;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface ICreateAirplaneValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken token);
}