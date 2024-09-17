using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Bookings;

public class CancelBooking(ICancelBookingService service) : Endpoint<CancelBookingRequest, Result>
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

    public override async Task HandleAsync(CancelBookingRequest request, CancellationToken ct)
    {
        var result = await service.CancelBookingStatus(request, ct);
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