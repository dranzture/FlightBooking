using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Requests;

public class UpdateFlightRequest(int seats, DateTime arrival, DateTime departure, FlightStatus status)
    : BaseDto<Guid>
{
    public int Seats { get; set; } = seats;

    public DateTime Arrival { get; set; } = arrival;

    public DateTime Departure { get; set; } = departure;

    public FlightStatus Status { get; set; } = status;
}