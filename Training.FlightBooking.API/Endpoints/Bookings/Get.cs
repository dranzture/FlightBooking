using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Bookings;

public class Get(IGetBookingService service) : Endpoint<Guid, Result<BookingDto>>
{
    private const string Route = "api/Booking/{id}";
    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(e =>
        {
            e.Description = "Gets a booking by id.";
            e.ExampleRequest = Guid.NewGuid();
        });
    }

    public override async Task HandleAsync(Guid id, CancellationToken ct)
    {
        var result = await service.GetBookingByIdAsync(id, ct);
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