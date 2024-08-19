using FastEndpoints;
using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class ListFlights : Endpoint<EmptyRequest, List<FlightDto>>
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