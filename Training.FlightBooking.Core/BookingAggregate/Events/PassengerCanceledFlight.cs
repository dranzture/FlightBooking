using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Events;

public class PassengerCanceledFlight(Guid flightId, Guid passengerId, int seats) : DomainEventBase
{
    public Guid FlightId { get; set; } = flightId;
    
    public int Seats { get; set; } = seats;
}