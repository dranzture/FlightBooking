using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Events;

public class PassengerCanceledFlight(Guid flightId, Passenger passenger, int seats) : DomainEventBase
{
    public Guid FlightId { get; set; } = flightId;
    public Passenger Passengers { get; set; } = passenger;
    
    public int Seats { get; set; } = seats;
}