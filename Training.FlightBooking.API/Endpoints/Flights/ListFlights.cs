using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class ListFlights : EndpointWithoutRequest<Result<IEnumerable<FlightDto>>>
{
    private const string Route = "/api/Flight/List";
    
    public override void Configure()
    {
        Get("/api/Flight/List");
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "List all flights";
            s.ExampleRequest = new EmptyRequest();
        });
    }
}