using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class CreateBookingRequest(Guid flightId, PassengerDto passenger, int seats)
{
    public Guid FlightId { get; private set; } = flightId;

    public PassengerDto Passenger { get; private set; } = passenger;

    public int Seats { get; private set; } = seats;
}
