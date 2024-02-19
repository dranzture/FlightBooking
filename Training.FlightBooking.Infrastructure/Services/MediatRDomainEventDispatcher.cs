using MediatR;
using Training.IntegrationTest.Infrastructure.Interfaces;
using DomainEventBase = Training.FlightBooking.Core.Shared.DomainEventBase;

namespace Training.FlightBooking.Core.Shared;

public class MediatRDomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;
    
    private readonly HashSet<Guid> _dispatchedEvents = new();


    public MediatRDomainEventDispatcher(IMediator mediator) => _mediator = mediator;
    
    public async Task DispatchAndClearEvents(IEnumerable<EntityBase<Guid>> entitiesWithEvents)
    {
        foreach (var entityWithEvents in entitiesWithEvents)
        {
            var eventsToDispatch = entityWithEvents.DomainEvents.Where(e => !_dispatchedEvents.Contains(e.EventId)).ToArray();
            
            entityWithEvents.ClearDomainEvents(); // Consider clearing after successful dispatch to prevent data loss on failure.

            foreach (var domainEvent in eventsToDispatch)
            {
                await _mediator.Publish<DomainEventBase>(domainEvent).ConfigureAwait(false);
                // Track successful dispatch.
                _dispatchedEvents.Add(domainEvent.EventId); 
            }
        }
    }
}