using MediatR;
using Training.IntegrationTest.Core.FlightAggregate.Events;

namespace Training.IntegrationTest.Core.BookingAggregate.Handlers;

internal class FlightIsReadyToDepartHandler : INotificationHandler<FlightIsReadyToDepart>
{
    public Task Handle(FlightIsReadyToDepart notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}