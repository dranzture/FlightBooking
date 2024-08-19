using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class BookingDto(FlightDto flight, PassengerDto passenger, int seats, BookingStatus status)
    : BaseDto<Guid>
{
    public FlightDto Flight { get; private set; } = flight;

    public PassengerDto Passenger { get; private set; } = passenger;

    public int Seats { get; private set; } = seats;

    public BookingStatus Status { get; private set; } = status;
}