using MediatR;
using Training.FlightBooking.Core.FlightAggregate.Events;

namespace Training.FlightBooking.Core.BookingAggregate.Handlers;

internal class FlightIsReadyToDepartHandler() : INotificationHandler<FlightIsReadyToDepart>
{
    public Task Handle(FlightIsReadyToDepart notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}