using MediatR;
using Training.FlightBooking.Core.FlightAggregate.Events;

namespace Training.IntegrationTest.Infrastructure.Handlers;

public class InformAirportsHandler : INotificationHandler<FlightCreated>
{
    public Task Handle(FlightCreated notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}