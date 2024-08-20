using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class Update(IUpdateAirplaneService service) : Endpoint<UpdateAirplaneRequest, Result>
{
    private const string Route = "/api/Airplanes/Update";

    public override void Configure()
    {
        Patch(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates a airplane.";
            e.ExampleRequest = new UpdateAirplaneRequest("Test Model", "Test Manufacturer", 2018);
        });
    }

    public override async Task HandleAsync(UpdateAirplaneRequest req, CancellationToken ct)
    {
        var result = await service.UpdateAirplane(req, ct);
        if (result is { IsSuccess: true })
        {
            await SendOkAsync(ct);
        }

        if (result is { IsSuccess: false, Errors.Count: > 0 })
        {
            ValidationFailures.AddRange(result.Errors);
            await SendErrorsAsync(cancellation: ct);
        }
    }
}