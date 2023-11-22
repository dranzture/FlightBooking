using MediatR;
using Training.IntegrationTest.Core.FlightAggregate.Events;

namespace Training.IntegrationTest.Core.BookingAggregate.Handlers;

internal class FlightIsAtFullCapacityHandler : INotificationHandler<FlightIsAtFullCapacity>
{
    public Task Handle(FlightIsAtFullCapacity notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}