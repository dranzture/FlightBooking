using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Events;

public class PassengerBookedFlight(Guid flightId, int seats) : DomainEventBase
{
    public Guid FlightId { get; set; } = flightId;
    
    public int Seats { get; set; } = seats;
}