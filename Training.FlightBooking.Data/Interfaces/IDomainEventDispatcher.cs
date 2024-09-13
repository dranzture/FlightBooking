using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Data.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<EntityBase<Guid>> entitiesWithEvents);
}