using FastEndpoints;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class UpdateFlightStatus(IUpdateFlightStatusService service) : Endpoint<UpdateFlightRequest, Result>
{
    private const string Route = "/api/Flight/UpdateFlightStatus";

    public override void Configure()
    {
        Put(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates an existing flight.";
            e.ExampleRequest =
                new UpdateFlightRequest(10, DateTime.Today, DateTime.Today.AddHours(-4), FlightStatus.OnTime)
                {
                    Id = Guid.NewGuid()
                };
        });
    }

    public override async Task HandleAsync(UpdateFlightRequest req, CancellationToken ct)
    {
        var result = await service.UpdateFlightStatus(req, ct);
        if (result is { IsSuccess: false, Errors.Count: > 0 })
        {
            ValidationFailures.AddRange(result.Errors);
            await SendErrorsAsync(cancellation: ct);
        }
        else
        {
            await SendOkAsync(result, ct);
        }
    }
}