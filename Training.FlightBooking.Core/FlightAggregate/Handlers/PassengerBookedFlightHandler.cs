using MediatR;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Events;

namespace Training.FlightBooking.Core.FlightAggregate.Handlers;

public class PassengerBookedFlightHandler
    : INotificationHandler<PassengerBookedFlight>
{
    private readonly IUpdateFlightAvailabilityService _updateFlightAvailabilityService;

    public PassengerBookedFlightHandler(IUpdateFlightAvailabilityService updateFlightAvailabilityService)
    {
        _updateFlightAvailabilityService = updateFlightAvailabilityService;
    }

    public async Task Handle(PassengerBookedFlight notification, CancellationToken cancellationToken)
    {
        await _updateFlightAvailabilityService.DecreaseFlightAvailability(notification.FlightId, notification.Seats,
            cancellationToken);
    }
}