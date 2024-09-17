using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class BookPassengersRequest(Guid flightId, IEnumerable<PassengerDto> passengers, int seats)
{
    public Guid FlightId { get; private set; } = flightId;
    
    public IEnumerable<PassengerDto> Passengers { get; private set; } = passengers;

    public int Seats { get; private set; } = seats;
}