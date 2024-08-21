using FluentValidation.Results;

namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface IUpdateAirplaneCapacityValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken cancellationToken);

}