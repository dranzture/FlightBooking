using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class CreateAirplaneService(
    IAirplaneRepository repository,
    IEnumerable<ICreateAirplaneValidationRule> rules,
    ILogger logger,
    IMapper mapper) : ICreateAirplaneService
{
    public async Task<Result<Guid>> CreateAirplaneAsync(CreateAirplaneRequest request,
        CancellationToken cancellationToken)
    {
        try
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
        catch (ArgumentException ex)
        {
            var validationFailures = new List<ValidationFailure>
                { new(nameof(Airplane), ex.Message) };
            return Result<Guid>.Failure(validationFailures);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. Request: {@Request}", nameof(CreateAirplaneService), request);

            var validationFailures = new List<ValidationFailure>
                { new(nameof(Airplane), "Something went wrong.") };

            return Result<Guid>.Failure(validationFailures);
        }
    }
}