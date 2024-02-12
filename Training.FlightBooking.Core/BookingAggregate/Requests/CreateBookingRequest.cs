using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class CreateBookingRequest(Flight flight, Passenger passenger, int seats)
{
    public Flight Flight { get; private set; } = flight;

    public Passenger Passenger { get; private set; } = passenger;

    public int Seats { get; private set; } = seats;
}
