using MediatR;
using Training.IntegrationTest.Core.BookingAggregate.Events;
using Training.IntegrationTest.Core.FlightAggregate.Interfaces;

namespace Training.IntegrationTest.Core.FlightAggregate.Handlers;

internal class PassengerBookedFlightHandler
    (IUpdateFlightAvailabilityService updateFlightAvailabilityService) : INotificationHandler<PassengerBookedFlight>
{
    public async Task Handle(PassengerBookedFlight notification, CancellationToken cancellationToken)
    {
        await updateFlightAvailabilityService.UpdateFlightAvailability(notification.FlightId, notification.Passengers,
            ObserveFlightAvailability.Decrease, cancellationToken);
    }
}