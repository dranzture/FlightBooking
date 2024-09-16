using MediatR;
using Training.FlightBooking.Core.Shared;
using Training.FlightBooking.Infrastructure.Interfaces;

// ReSharper disable once CheckNamespace
namespace Training.FlightBooking.Infrastructure.Services;

public class DomainEventDispatcher(IMediator mediator) : IDomainEventDispatcher
{
    private readonly HashSet<Guid> _dispatchedEvents = new();


    public async Task DispatchAndClearEvents(IEnumerable<EntityBase<Guid>> entitiesWithEvents)
    {
        foreach (var entityWithEvents in entitiesWithEvents)
        {
            var eventsToDispatch = entityWithEvents.DomainEvents.Where(e => !_dispatchedEvents.Contains(e.EventId)).ToArray();
            
            entityWithEvents.ClearDomainEvents(); // Consider clearing after successful dispatch to prevent data loss on failure.

            foreach (var domainEvent in eventsToDispatch)
            {
                await mediator.Publish(domainEvent).ConfigureAwait(false);
                // Track successful dispatch.
                _dispatchedEvents.Add(domainEvent.EventId); 
            }
        }
    }
}