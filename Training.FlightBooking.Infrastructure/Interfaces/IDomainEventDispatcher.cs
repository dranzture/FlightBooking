using Training.FlightBooking.Core.Shared;

// ReSharper disable once CheckNamespace
namespace Training.FlightBooking.Infrastructure.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<EntityBase<Guid>> entitiesWithEvents);
}