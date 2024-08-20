using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Domain;

public class NotExistingUpdateAirplaneValidationRule(IRepository<Airplane> repository) : IUpdateAirplaneValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken cancellationToken)
    {
        var existingAirplane = await repository.GetByIdAsync(airplane.Id, cancellationToken);
        return existingAirplane is not null
            ? new ValidationFailure(nameof(Airplane), "Airplane already exists.")
            : null;
    }
}