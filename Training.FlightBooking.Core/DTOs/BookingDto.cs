namespace Training.FlightBooking.Core.DTOs;

public class BookingDto(FlightDto flight, PassengerDto passenger, int seats)
{
    public FlightDto Flight { get;  set; } = flight;

    public PassengerDto Passenger { get; set; } = passenger;

    private int Seats { get; set; } = seats;
}