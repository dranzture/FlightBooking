using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.BookingAggregate.Events;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate;

public class Booking : Shared.EntityBase<Guid>, IAggregateRoot
{
    public Booking()
    {
    }

    public Booking(Guid id)
    {
        Id = id;
    }
    
    /// <summary>
    /// Initializes a new instance of the Booking class with the specified flight.
    /// </summary>
    /// <param name="flight">The flight associated with the booking.</param>
    /// <param name="seats">Seats to be booked.</param>
    /// <param name="passenger">Passenger to book flight.</param>
    public Booking(Guid flightId, int seats)
    {
        FlightId = flightId;
        
        Seats = Guard.Against.NegativeOrZero(seats);

        Id = new Guid();
    }


    public Flight Flight { get; private set; }

    public Guid FlightId { get; private set; }

    public Passenger Passenger { get; private set; }

    public Guid PassengerId { get; private set; }

    public int Seats { get; private set; }

    public BookingStatus Status { get; private set; } = BookingStatus.Active;

    public void CancelBooking()
    {
        Status = BookingStatus.Canceled;
        RegisterDomainEvent(new PassengerCanceledFlight(FlightId, PassengerId, Seats));
    }

    
    public void AddPassenger(Guid passengerId)
    {
        PassengerId = passengerId;
        RegisterDomainEvent(new PassengerBookedFlight(FlightId, Seats));
    }
}