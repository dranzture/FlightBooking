using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;
using IMapper = AutoMapper.IMapper;
namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class Create(ICreateAirplaneService createAirplaneService, IMapper mapper) : Endpoint<CreateAirplaneRequest, Result<Guid>>
{
    private const string Route = "/api/Airplanes/Create";
    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Creates a new airplane.";
            e.ExampleRequest = new CreateAirplaneRequest(new AirplaneDto("Test Model", "Test Manufacturer", 250, 2018));
        });
    }

    public override async Task HandleAsync(CreateAirplaneRequest req, CancellationToken ct)
    {
        var result = await createAirplaneService.CreateAirplaneAsync(req, ct);
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