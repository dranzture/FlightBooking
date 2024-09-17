using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class UpdateFlightStatusService(IFlightRepository repository, ILogger logger)
    : IUpdateFlightStatusService
{
    public async Task<Result> UpdateFlightStatus(UpdateFlightRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var flight = await repository.GetByIdAsync(request.Id, cancellationToken);
            if (flight is null)
            {
                var validationFailures = new List<ValidationFailure>
                    { new(nameof(Flight), "Flight not found") };
                return Result<Guid>.Failure(validationFailures);
            }

            flight.UpdateStatus(request.Status);
            await repository.UpdateAsync(flight, cancellationToken);

            return Result.Success();
        }
        catch (ArgumentException ex)
        {
            var validationFailures = new List<ValidationFailure>
                { new(nameof(Flight), ex.Message) };
            return Result<Guid>.Failure(validationFailures);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. Request: {@Request}", nameof(UpdateFlightStatusService), request);

            var validationFailures = new List<ValidationFailure>
                { new(nameof(Flight), "Something went wrong.") };

            return Result<Guid>.Failure(validationFailures);
        }
    }
}