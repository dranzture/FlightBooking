using MediatR;
using Training.FlightBooking.Core.Shared;

namespace Training.IntegrationTest.Infrastructure.Handlers;

public class SendNotificationHandler : INotificationHandler<SendNotification>
{
    public Task Handle(SendNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}