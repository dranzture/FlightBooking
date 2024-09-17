using AutoMapper;
using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class CreateFlightService(
    IFlightRepository repository,
    ILogger logger,
    IEnumerable<ICreateFlightValidationRule> rules,
    IMapper mapper) : ICreateFlightService
{
    public async Task<Result<Guid>> CreateFlight(CreateFlightRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var flight = mapper.Map<Flight>(request.Flight);
            var validationFailures = new List<ValidationFailure>();

            foreach (var rule in rules)
            {
                var validationFailure = await rule.ValidateAsync(flight, cancellationToken);
                if (validationFailure is not null)
                {
                    validationFailures.Add(validationFailure);
                }
            }

            if (validationFailures.Count > 0)
            {
                return Result<Guid>.Failure(validationFailures);
            }

            await repository.AddAsync(flight, cancellationToken);

            return Result<Guid>.Success(flight.Id);
        }
        catch (ArgumentException ex)
        {
            var validationFailures = new List<ValidationFailure>
                { new(nameof(Flight), ex.Message) };
            return Result<Guid>.Failure(validationFailures);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. Request: {@Request}", nameof(CreateFlightService), request);

            var validationFailures = new List<ValidationFailure>
                { new(nameof(Flight), "Something went wrong.") };

            return Result<Guid>.Failure(validationFailures);
        }
    }
}