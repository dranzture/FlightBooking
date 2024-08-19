using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class Update : Endpoint<UpdateAirplaneRequest, AirplaneDto>
{
    private const string Route = "/api/Airplanes/Update";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates a airplane.";
            e.ExampleRequest = new UpdateAirplaneRequest("Test Model", "Test Manufacturer", 2018);
        });
    }

    public override async Task HandleAsync(UpdateAirplaneRequest req, CancellationToken ct)
    {
        //var result = await createAirplaneService.CreateAirplane(mapper.Map<Airplane>(req.Airplane), ct);
        await SendOkAsync(ct);
    }
}