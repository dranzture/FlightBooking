using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Requests;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class Update : Endpoint<UpdateFlightRequest, FlightDto>
{
    private const string Route = "/api/Flight/Update";

    public override void Configure()
    {
        Put(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Updates an existing flight.";
            e.ExampleRequest =
                new UpdateFlightRequest(10, DateTime.Today, DateTime.Today.AddHours(-4), FlightStatus.OnTime)
                {
                    Id = Guid.NewGuid()
                };
        });
    }
}