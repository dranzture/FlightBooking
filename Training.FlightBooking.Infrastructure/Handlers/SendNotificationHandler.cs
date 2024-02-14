using MediatR;
using Training.FlightBooking.Core.Shared;

namespace Training.IntegrationTest.Infrastructure.Handlers;

public class SendNotificationHandler : INotificationHandler<SendNotification>
{
    public Task Handle(SendNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Sent notification to Passenger's email: {notification.Passenger.Email}");
        if (notification.Itinerary is not null)
        {
            Console.WriteLine($"Sent notification to Itinerary's email: {notification.Itinerary.Email}");
        }

        return Task.CompletedTask;
    }
}