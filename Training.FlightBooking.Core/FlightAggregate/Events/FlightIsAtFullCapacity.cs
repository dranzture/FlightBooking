using Ardalis.SharedKernel;

namespace Training.FlightBooking.Core.FlightAggregate.Events;

internal class FlightIsAtFullCapacity(Flight flight) : DomainEventBase
{
    public readonly Flight Flight = flight;
}