using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Validations;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Domain;

public class AirplaneExistsValidationRule(IAirplaneRepository repository) : IUpdateAirplaneValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken cancellationToken)
    {
        var existingAirplane = await repository.GetByIdAsync(airplane.Id, cancellationToken);
        
        return existingAirplane is null
            ? new ValidationFailure(nameof(Airplane), "Airplane does not exists.")
            : null;
    }
}