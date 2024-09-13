using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Domain;

public class ExistingCreateAirplaneValidationRule(IAirplaneRepository repository) : ICreateAirplaneValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken token)
    {
        var existingAirplane = await repository.FindByModelManufacturerAndYear(airplane.Model, airplane.Manufacturer, airplane.Year, token);
        return existingAirplane is not null
            ? new ValidationFailure(nameof(Airplane), "Airplane already exists.")
            : null;
    }
}