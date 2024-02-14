using FastEndpoints;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;

namespace Training.FlightBooking.API.Endpoints.Airplane;

public class UpdateCapacity(IUpdateAirplaneCapacityService updateCapacityService) : Endpoint<UpdateCapacityRequest>
{
    public override void Configure()
    {
        Patch("/api/Airplane/UpdateCapacity");
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates capacity of an airplane.";
            e.ExampleRequest = new UpdateCapacityRequest(new Guid(), 250);
        });
    }

    public override async Task HandleAsync(UpdateCapacityRequest req, CancellationToken ct)
    {
        await updateCapacityService.UpdateCapacity(req.Id, req.Capacity, ct);
        await SendOkAsync(ct);
    }
}