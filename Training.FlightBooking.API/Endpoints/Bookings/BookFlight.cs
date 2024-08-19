using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.API.Endpoints.Bookings;

public class BookFlight(IBookPassengerService service, IMapper mapper) : Endpoint<CreateBookingRequest, Guid>
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
        var response = await service.BookPassenger(req.FlightId, req.PassengerId, req.Seats, ct);
        await SendOkAsync(response, ct);
    }
}