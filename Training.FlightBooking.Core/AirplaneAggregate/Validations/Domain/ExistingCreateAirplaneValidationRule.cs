using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Specifications;

namespace Training.FlightBooking.Core.AirplaneAggregate.Validations.Domain;

public class ExistingCreateAirplaneValidationRule(IRepository<Airplane> repository) : ICreateAirplaneValidationRule
{
    public async Task ValidateAsync(Airplane airplane, CancellationToken token)
    {
        var passengerNoTrack = new FindByModelManufacturerAndYear(airplane.Model, airplane.Manufacturer, airplane.Year);
        var passenger = await repository.FirstOrDefaultAsync(passengerNoTrack, token);
        if (passenger is not null) throw new ArgumentException("Airplane already exists.");
    }
}