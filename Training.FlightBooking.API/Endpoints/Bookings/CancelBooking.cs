using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Bookings;

public class CancelBooking(ICancelBookingService service) : Endpoint<Guid, Result>
{
    private const string Route = "api/Bookings/Cancel/{id}";

    public override void Configure()
    {
        Delete(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Cancels a booking";
            s.ExampleRequest = Guid.NewGuid();
        });
    }

    public override async Task HandleAsync(Guid id, CancellationToken ct)
    {
        var result = await service.CancelBookingStatus(id, ct);
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