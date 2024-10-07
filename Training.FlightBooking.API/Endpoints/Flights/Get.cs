using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class Get(IGetFlightById service) : Endpoint<GetFlightByIdRequest, Result<FlightDto?>>
{
    private const string Route = "api/Flight/{id}";

    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Gets a flight by id.";
            e.ExampleRequest = new GetFlightByIdRequest() { Id = Guid.NewGuid() };
        });
    }

    public override async Task HandleAsync(GetFlightByIdRequest req, CancellationToken ct)
    {
        var result = await service.GetFlightByIdAsync(req.Id, ct);
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