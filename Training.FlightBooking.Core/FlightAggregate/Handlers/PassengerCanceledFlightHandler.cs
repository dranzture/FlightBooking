using MediatR;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Events;

namespace Training.FlightBooking.Core.FlightAggregate.Handlers;

internal class PassengerCanceledFlightHandler(IUpdateFlightAvailabilityService updateFlightAvailabilityService)
    : INotificationHandler<PassengerCanceledFlight>
{
    public async Task Handle(PassengerCanceledFlight notification, CancellationToken cancellationToken)
    {
        await updateFlightAvailabilityService.UpdateFlightAvailability(notification.FlightId,
            notification.Seats,
            ObserveFlightAvailability.Increase, cancellationToken);
    }
}