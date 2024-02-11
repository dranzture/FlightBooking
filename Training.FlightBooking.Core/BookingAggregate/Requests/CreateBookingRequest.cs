using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class CreateBookingRequest(Flight flight)
{
    public Flight Flight { get; private set; } = flight;
}
