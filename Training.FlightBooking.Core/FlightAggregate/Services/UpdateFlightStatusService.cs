using FluentValidation.Results;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class UpdateFlightStatusService(IFlightRepository repository)
    : IUpdateFlightStatusService
{
    public async Task<Result> UpdateFlightStatus(UpdateFlightRequest request, CancellationToken cancellationToken)
    {
        var flight = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (flight is null)
        {
            var validationFailures = new List<ValidationFailure>
                { new (nameof(Flight), "Flight not found") };
            return Result<Guid>.Failure(validationFailures);
        }

        flight.UpdateStatus(request.Status);
        await repository.UpdateAsync(flight, cancellationToken);

        return Result.Success();
    }
}