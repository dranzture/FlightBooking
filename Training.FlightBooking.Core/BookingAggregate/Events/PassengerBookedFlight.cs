using Ardalis.SharedKernel;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Events;

public class PassengerBookedFlight(Guid flightId, Passenger passenger, int seats) : DomainEventBase
{
    public Guid FlightId { get; set; } = flightId;
    public Passenger Passenger { get; set; } = passenger;
    
    public int Seats { get; set; } = seats;
}