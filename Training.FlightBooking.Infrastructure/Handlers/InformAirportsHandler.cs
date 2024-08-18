using MediatR;
using Training.FlightBooking.Core.Shared;

namespace Training.IntegrationTest.Infrastructure.Handlers;

public class InformAirportsHandler : INotificationHandler<SendNotification>
{
    
    public Task Handle(SendNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Sending notification to airports for a new flight created.");

        return Task.CompletedTask;
    }
}