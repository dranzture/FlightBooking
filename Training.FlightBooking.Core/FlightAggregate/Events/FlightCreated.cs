using Ardalis.SharedKernel;

namespace Training.IntegrationTest.Core.FlightAggregate.Events;

internal class FlightCreated(Flight flight) : DomainEventBase
{
    public readonly Flight Flight = flight;
}