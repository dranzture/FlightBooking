using Training.FlightBooking.Core.Shared;

namespace Training.IntegrationTest.Infrastructure.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<EntityBase<Guid>> entitiesWithEvents);
}