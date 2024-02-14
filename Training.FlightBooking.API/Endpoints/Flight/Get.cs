using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Guid = System.Guid;

namespace Training.FlightBooking.API.Endpoints.Flight;

public class Get : Endpoint<Guid, BookingDto>
{
    public override void Configure()
    {
        Get("/api/Flight/GetById");
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Creates a new airplane.";
            e.ExampleRequest = new Guid();
        });
    }

    public override async Task HandleAsync(Guid id, CancellationToken ct)
    {
        // var flight = mapper.Map<BookingDto>(await service.GetFlightById(id, ct));
        await SendOkAsync(new BookingDto(
            new FlightDto(
                new Guid(),
                120,
                new LocationDto("LAX", "Los Angeles"),
                new LocationDto("JFK", "New York"),
                DateTime.Now.AddDays(2).AddHours(12), 
                DateTime.Now.AddDays(2)),
            new PassengerDto(
                "Polat", 
                "Coban", 
                "polatcoban@gmail.com", 
                new DateTime(1990, 8, 28)), 2), ct);
    }
}