using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class Create(ICreateFlightService createFlightService, IMapper mapper) : Endpoint<CreateFlightRequest>
{
    private const string Route = "api/Flight/Create";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Create a new flight";
            s.ExampleRequest = new CreateFlightRequest(
                new FlightDto(
                    new Guid(),
                    120,
                    new LocationDto("LAX", "Los Angeles"),
                    new LocationDto("JFK", "New York"),
                    DateTime.Now.AddDays(2).AddHours(12),
                    DateTime.Now.AddDays(2),
                    FlightStatus.OnTime
                ));
        });
    }

    public override async Task HandleAsync(CreateFlightRequest req, CancellationToken ct)
    {
        var result = await createFlightService.CreateFlight(req, ct);
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