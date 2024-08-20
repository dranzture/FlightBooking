using FastEndpoints;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class UpdateCapacity(IUpdateAirplaneCapacityService updateCapacityService)
    : Endpoint<UpdateAirplaneCapacityRequest, Result>
{
    private const string Route = "/api/Airplanes/UpdateCapacity";

    public override void Configure()
    {
        Patch(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates capacity of an airplane.";
            e.ExampleRequest = new UpdateAirplaneCapacityRequest(new Guid(), 250);
        });
    }

    public override async Task HandleAsync(UpdateAirplaneCapacityRequest req, CancellationToken ct)
    {
        var result = await updateCapacityService.UpdateCapacityAsync(req, ct);
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