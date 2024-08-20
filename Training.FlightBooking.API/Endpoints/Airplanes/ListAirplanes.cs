using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class ListAirplanes(IListAirplanesService service) : EndpointWithoutRequest<Result<IEnumerable<AirplaneDto>>>
{
    private const string Route = "api/Airplanes/List";
    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Lists airplanes.";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await service.ListAirplanesAsync(ct);
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