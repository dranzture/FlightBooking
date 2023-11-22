using Ardalis.SharedKernel;

namespace Training.IntegrationTest.Core.FlightAggregate.Events;

internal class FlightIsReadyToDepart(Flight flight) : DomainEventBase
{
    public Flight Flight { get; set; } = flight;
    
}
