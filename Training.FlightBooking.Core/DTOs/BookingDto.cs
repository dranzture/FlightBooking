using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class BookingDto(FlightDto flight, PassengerDto passenger, int seats, BookingStatus status) : BaseDto<Guid>
{
    public FlightDto Flight { get;  set; } = flight;

    public PassengerDto Passenger { get; set; } = passenger;

    public int Seats { get; set; } = seats;

    public BookingStatus Status { get; set; } = status;
}