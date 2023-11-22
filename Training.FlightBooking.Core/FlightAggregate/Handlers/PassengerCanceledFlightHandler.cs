using MediatR;
using Training.IntegrationTest.Core.BookingAggregate.Events;
using Training.IntegrationTest.Core.FlightAggregate.Interfaces;

namespace Training.IntegrationTest.Core.FlightAggregate.Handlers;

internal class PassengerCanceledFlightHandler
    (IUpdateFlightAvailabilityService updateFlightAvailabilityService) : INotificationHandler<PassengerCanceledFlight>
{
    public async Task Handle(PassengerCanceledFlight notification, CancellationToken cancellationToken)
    {
        await updateFlightAvailabilityService.UpdateFlightAvailability(notification.FlightId, notification.Passengers,
            ObserveFlightAvailability.Increase, cancellationToken);
    }
}