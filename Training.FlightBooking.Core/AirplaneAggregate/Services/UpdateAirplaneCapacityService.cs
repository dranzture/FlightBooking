using AutoMapper;
using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneCapacityService(
    IAirplaneRepository repository,
    ILogger logger,
    IMapper mapper,
    IEnumerable<IUpdateAirplaneValidationRule> rules) : IUpdateAirplaneCapacityService
{
    public async Task<Result> UpdateCapacityAsync(UpdateAirplaneCapacityRequest request,
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

            airplane.UpdateCapacity(request.Capacity);

            await repository.UpdateAsync(airplane, cancellationToken);

            return Result.Success();
        }
        catch (ArgumentException ex)
        {
            var validationFailures = new List<ValidationFailure>
                { new(nameof(Airplane), ex.Message) };
            return Result.Failure(validationFailures);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. Request: {@Request}", nameof(UpdateAirplaneCapacityRequest), request);

            var validationFailures = new List<ValidationFailure>
                { new(nameof(Airplane), "Something went wrong.") };

            return Result.Failure(validationFailures);
        }
    }
}