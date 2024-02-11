using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Core.FlightAggregate.Events;

internal class FlightIsReadyToDepart(Flight flight) : DomainEventBase
{
    public readonly Flight Flight = flight;
}
