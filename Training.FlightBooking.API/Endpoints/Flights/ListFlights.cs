using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Flights;

public class ListFlights(IListFlightsService service) : EndpointWithoutRequest<Result<IEnumerable<FlightDto>>>
{
    private const string Route = "/api/Flight/List";
    
    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "List all flights";
            s.ExampleRequest = new EmptyRequest();
        });
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var bookings = await service.ListFlights(ct);
        await SendOkAsync(bookings, ct);
    }
}