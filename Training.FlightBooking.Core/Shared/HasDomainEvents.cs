using System.ComponentModel.DataAnnotations.Schema;

namespace Training.FlightBooking.Core.Shared;

public abstract class HasDomainEventsBase
{
    private List<DomainEventBase> _domainEvents = new();
    
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    
    public void ClearDomainEvents() => _domainEvents.Clear();
}