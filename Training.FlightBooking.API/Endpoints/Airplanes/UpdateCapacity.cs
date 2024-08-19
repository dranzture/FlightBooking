using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;

namespace Training.FlightBooking.API.Endpoints.Airplanes;

public class UpdateCapacity(IUpdateAirplaneCapacityService updateCapacityService) : Endpoint<UpdateCapacityRequest>
{
    private const string Route = "/api/Airplanes/UpdateCapacity";
    public override void Configure()
    {
        Patch(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates capacity of an airplane.";
            e.ExampleRequest = new UpdateCapacityRequest(new Guid(), 250);
        });
    }

    public override async Task HandleAsync(UpdateCapacityRequest req, CancellationToken ct)
    {
        await updateCapacityService.UpdateCapacityAsync(req.Id, req.Capacity, ct);
        await SendOkAsync(ct);
    }
}