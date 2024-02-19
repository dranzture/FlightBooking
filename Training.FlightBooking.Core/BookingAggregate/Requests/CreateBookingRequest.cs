using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class CreateBookingRequest(Guid flightId, Guid passengerId, int seats)
{
    public Guid FlightId { get; set; } = flightId;

    public Guid PassengerId { get; set; } = passengerId;

    public int Seats { get; set; } = seats;
}
