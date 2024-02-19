namespace Training.FlightBooking.Core.Shared;


public abstract class EntityBase<T> : HasDomainEventsBase
{
    public T Id { get; set; }
}