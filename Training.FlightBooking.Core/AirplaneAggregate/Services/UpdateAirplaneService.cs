using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneService(
    IAirplaneRepository repository,
    IMapper mapper,
    IEnumerable<IUpdateAirplaneValidationRule> rules) : IUpdateAirplaneService
{
    public async Task<Result> UpdateAirplane(UpdateAirplaneRequest req, CancellationToken cancellationToken)
    {
        var airplane = mapper.Map<Airplane>(req);

        var validationFailures = new List<ValidationFailure>();

        foreach (var rule in rules)
        {
            var validationFailure = await rule.ValidateAsync(airplane, cancellationToken);
            if (validationFailure is not null)
            {
                validationFailures.Add(validationFailure);
            }
        }

        if (validationFailures.Count > 0)
        {
            return Result<Guid>.Failure(validationFailures);
        }
        
        await repository.UpdateAsync(airplane, cancellationToken);

        return Result.Success();
    }
}