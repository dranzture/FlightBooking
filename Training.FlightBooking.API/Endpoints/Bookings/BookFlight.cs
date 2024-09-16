using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Bookings;

public class BookFlight(IBookPassengerService service) : Endpoint<CreateBookingRequest, Result<Guid>>
{
    private const string Route = "api/Bookings/Create";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Create a new flight";
            s.ExampleRequest = new CreateBookingRequest(new Guid(),
                new Guid(), 2);
        });
    }

    public override async Task HandleAsync(CreateBookingRequest req, CancellationToken ct)
    {
        var result = await service.BookPassenger(req.FlightId, req.PassengerId, req.Seats, ct);
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