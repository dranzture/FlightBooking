using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class FlightDto : BaseDto<Guid>
{
    public FlightDto()
    {
    }
    public FlightDto(Guid airplaneId,
        int availableSeats,
        LocationDto from,
        LocationDto to,
        DateTime arrival,
        DateTime departure,
        FlightStatus status)
    {
        To = to;
        From = from;
        Arrival = arrival;
        Departure = departure;
        AvailableSeats = availableSeats;
        Status = status;
        AirplaneId = airplaneId;
    }

    public LocationDto To { get; private set; }

    public LocationDto From { get; private set; }

    public DateTime Arrival { get; private set; }

    public DateTime Departure { get; private set; }

    public int AvailableSeats { get; private set; }

    public FlightStatus Status { get; private set; }

    public Guid AirplaneId { get; private set; }
}