using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.PassengerAggregate;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.API.Endpoints.Booking;

public class BookFlight(IBookPassengerService service, IMapper mapper) : Endpoint<CreateBookingRequest, Guid>
{
    private const string Route = "api/Booking/Create";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Create a new flight";
            s.ExampleRequest = new CreateBookingRequest(new Guid(),
                new PassengerDto("Polat", "Coban", "polatcoban@gmail.com", new DateOnly(1990, 8, 28)), 2);
        });
    }

    public override async Task HandleAsync(CreateBookingRequest req, CancellationToken ct)
    {
        var response = await service.BookPassenger(req.FlightId, mapper.Map<Passenger>(req.Passenger), req.Seats, ct);
        await SendOkAsync(response, ct);
    }
}