using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Specifications;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Domain;

public class ExistingCreateAirplaneValidationRule(IRepository<Airplane> repository) : ICreateAirplaneValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Airplane airplane, CancellationToken token)
    {
        var newAirplane = new FindByModelManufacturerAndYear(airplane.Model, airplane.Manufacturer, airplane.Year);
        var existingAirplane = await repository.FirstOrDefaultAsync(newAirplane, token);
        return existingAirplane is not null
            ? new ValidationFailure(nameof(Airplane), "Airplane already exists.")
            : null;
    }
}