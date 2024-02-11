using MediatR;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Events;
using Training.FlightBooking.Core.FlightAggregate.Events;

namespace Training.FlightBooking.Core.BookingAggregate.Handlers;

internal class FlightIsAtFullCapacityHandler(IUpdateBookingStatusService service) : INotificationHandler<FlightIsAtFullCapacity>
{
    public async Task Handle(FlightIsAtFullCapacity notification, CancellationToken cancellationToken)
    {
        await service.UpdateBookingStatus(notification.Flight, BookingStatus.Closed, cancellationToken);
    }
}