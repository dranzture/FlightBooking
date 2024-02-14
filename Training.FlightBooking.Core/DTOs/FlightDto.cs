using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class FlightDto(Guid airplaneId, int availableSeats, LocationDto from, LocationDto to, DateTime arrival, DateTime departure) : BaseDto<Guid>
{
    public LocationDto To { get; private set; } = to;

    public LocationDto From { get; private set; } = from;

    public DateTime Arrival { get; private set; } = arrival;

    public DateTime Departure { get; private set; } = departure;

    public int AvailableSeats { get; private set; } = availableSeats;
    
    public Guid AirplaneId { get; private set; } = airplaneId;
}