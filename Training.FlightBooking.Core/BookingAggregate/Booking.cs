using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.BookingAggregate.Events;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate;

public class Booking : EntityBase<Guid>, IAggregateRoot
{
    public Booking(){}
    
    /// <summary>
    /// Initializes a new instance of the Booking class with the specified flight.
    /// </summary>
    /// <param name="flight">The flight associated with the booking.</param>
    /// <param name="seats">Seats to be booked.</param>
    /// <param name="passenger">Passenger to book flight.</param>
    public Booking(Flight flight, Passenger passenger, int seats)
    {
        Flight = flight;
        FlightId = flight.Id;
        
        Passenger = passenger;
        PassengerId = passenger.Id;
        
        Seats = Guard.Against.NegativeOrZero(seats);
        
        Id = new Guid();
        RegisterDomainEvent(new PassengerBookedFlight(FlightId, Passenger, Seats));
    }
    
    
    public Flight Flight { get; private set; }
    
    public Guid FlightId { get; private set; }
    
    public Passenger Passenger { get;  set; }
    
    public Guid PassengerId { get; private set; }
    
    private int Seats { get;  set; }
   
    public BookingStatus Status { get; private set; } = BookingStatus.Active;

    public void CancelBooking()
    {
        RegisterDomainEvent(new PassengerCanceledFlight(FlightId, Passenger, Seats));
    }
    
}