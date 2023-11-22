using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.FlightAggregate;
using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.BookingAggregate.Events;

public class PassengerCanceledFlight(Guid flightId, List<Passenger> passengers) : DomainEventBase
{
    public Guid FlightId { get; set; } = flightId;
    public List<Passenger> Passengers { get; set; } = passengers;
}