using MediatR;
using Training.IntegrationTest.Core.BookingAggregate.Interfaces;
using Training.IntegrationTest.Core.FlightAggregate.Events;

namespace Training.IntegrationTest.Core.BookingAggregate.Handlers;

internal class FlightCreatedHandler(ICreateBookingService createBookingService) : INotificationHandler<FlightCreated>
{
    public async Task Handle(FlightCreated notification, CancellationToken cancellationToken)
    {
        await createBookingService.CreateBooking(new Booking(notification.Flight), cancellationToken);
    }
}