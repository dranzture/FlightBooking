using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class FlightDto(LocationDto from, LocationDto to, DateTime arrival, DateTime departure, int availableSeats, AirplaneDto plane) : BaseDto<Guid>
{
    public LocationDto To { get; private set; } = to;

    public LocationDto From { get; private set; } = from;

    public DateTime Arrival { get; private set; } = arrival;

    public DateTime Departure { get; private set; } = departure;

    public int AvailableSeats { get; private set; } = availableSeats;

    public AirplaneDto Plane { get; private set; } = plane;
}