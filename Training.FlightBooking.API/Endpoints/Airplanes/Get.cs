using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class Get(IGetAirplaneService service) : Endpoint<Guid, Result<AirplaneDto>>
{
    private const string Route = "api/Airplanes/{id}";
    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Gets an airplane by id.";
            e.ExampleRequest = Guid.NewGuid();
        });
    }

    public override async Task HandleAsync(Guid id, CancellationToken ct)
    {
        var result = await service.GetAirplaneAsync(id, ct);
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