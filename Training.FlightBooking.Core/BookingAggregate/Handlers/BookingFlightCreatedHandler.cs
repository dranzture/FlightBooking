using MediatR;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.FlightAggregate.Events;

namespace Training.FlightBooking.Core.BookingAggregate.Handlers;

public class BookingFlightCreatedHandler(ICreateBookingService service)
    : INotificationHandler<FlightCreated>
{
    public async Task Handle(FlightCreated notification, CancellationToken cancellationToken)
    {
        await service.CreateBooking(new CreateBookingRequest(notification.Flight),
            cancellationToken);
    }
}