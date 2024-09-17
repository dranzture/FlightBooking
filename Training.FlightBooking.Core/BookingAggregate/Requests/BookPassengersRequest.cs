using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class BookPassengersRequest(Guid flightId, Guid passengerId, int seats)
{
    public Guid FlightId { get; private set; } = flightId;
    
    public Guid PassengerId { get; private set; } = passengerId;

    public int Seats { get; private set; } = seats;
}