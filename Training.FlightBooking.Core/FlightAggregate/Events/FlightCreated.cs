using Ardalis.SharedKernel;

namespace Training.FlightBooking.Core.FlightAggregate.Events;

public class FlightCreated(Flight flight) : DomainEventBase
{
    public readonly Flight Flight = flight;
}