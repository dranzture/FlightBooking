using MediatR;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Events;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;

namespace Training.FlightBooking.Core.FlightAggregate.Handlers;

public class PassengerCanceledFlightHandler(IUpdateFlightAvailabilityService updateFlightAvailabilityService)
    : INotificationHandler<PassengerCanceledFlight>
{
    public async Task Handle(PassengerCanceledFlight notification, CancellationToken cancellationToken)
    {
        await updateFlightAvailabilityService.IncreaseFlightAvailability(notification.FlightId,
            notification.Seats, cancellationToken);
    }
}