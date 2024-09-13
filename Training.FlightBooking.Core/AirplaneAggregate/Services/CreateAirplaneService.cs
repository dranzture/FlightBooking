using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class CreateAirplaneService(
    IAirplaneRepository repository,
    IEnumerable<ICreateAirplaneValidationRule> rules,
    IMapper mapper) : ICreateAirplaneService
{
    public async Task<Result<Guid>> CreateAirplaneAsync(CreateAirplaneRequest request,
        CancellationToken cancellationToken)
    {
        var airplane = mapper.Map<Airplane>(request);
        
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

        await repository.AddAsync(airplane, cancellationToken);
        return Result<Guid>.Success(airplane.Id);
    }
}