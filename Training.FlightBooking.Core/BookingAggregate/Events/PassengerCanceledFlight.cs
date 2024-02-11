using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Events;

public class PassengerCanceledFlight(Guid flightId, List<Passenger> passengers) : DomainEventBase
{
    public Guid FlightId { get; set; } = flightId;
    public List<Passenger> Passengers { get; set; } = passengers;
}