using MediatR;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Events;

namespace Training.FlightBooking.Core.FlightAggregate.Handlers;

internal class PassengerBookedFlightHandler(IUpdateFlightAvailabilityService updateFlightAvailabilityService)
    : INotificationHandler<PassengerBookedFlight>
{
    public async Task Handle(PassengerBookedFlight notification, CancellationToken cancellationToken)
    {
        await updateFlightAvailabilityService.UpdateFlightAvailability(notification.FlightId, notification.Seats,
            ObserveFlightAvailability.Decrease, cancellationToken);
    }
}