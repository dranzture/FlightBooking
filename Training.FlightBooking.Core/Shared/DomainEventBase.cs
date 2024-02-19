using MediatR;

namespace Training.FlightBooking.Core.Shared;

public abstract class DomainEventBase : INotification
{
    public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
    
    public Guid EventId { get; private set; } = Guid.NewGuid();
}