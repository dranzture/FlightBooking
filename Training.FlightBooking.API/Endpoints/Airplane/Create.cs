using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.DTOs;
using IMapper = AutoMapper.IMapper;
namespace Training.FlightBooking.API.Endpoints.Airplane;

public class Create(ICreateAirplaneService createAirplaneService, IMapper mapper) : Endpoint<CreateAirplaneRequest, Guid>
{
    public override void Configure()
    {
        Post("/api/Airplane/Create");
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Creates a new airplane.";
            e.ExampleRequest = new CreateAirplaneRequest(new AirplaneDto("Test Model", "Test Manufacturer", 250, 2018));
        });
    }

    public override async Task HandleAsync(CreateAirplaneRequest req, CancellationToken ct)
    {
        var result = await createAirplaneService.CreateAirplane(mapper.Map<Core.AirplaneAggregate.Airplane>(req.Airplane), ct);
        await SendOkAsync(result, ct);
    }
}