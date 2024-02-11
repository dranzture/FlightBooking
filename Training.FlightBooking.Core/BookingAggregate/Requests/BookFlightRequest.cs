using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.BookingAggregate.Requests;

public class BookFlightRequest(Guid flightId, IEnumerable<PassengerDto> passengers)
{
    public Guid FlightId { get; private set; } = flightId;
    
    public IEnumerable<PassengerDto> Passengers { get; private set; } = passengers;
}