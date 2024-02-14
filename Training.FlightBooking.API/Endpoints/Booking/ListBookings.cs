using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.DTOs;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.API.Endpoints.Booking;

public class ListBookings(IRetrieveAllBookingsService service, IMapper mapper) : EndpointWithoutRequest<IEnumerable<BookingDto>>
{
    private const string Route = "api/Booking/List";

    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Retrieves all bookings.";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var bookings = mapper.Map<IEnumerable<BookingDto>>(await service.GetAllBookings(ct));
        await SendOkAsync(bookings, ct);
    }
}

