using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.FlightAggregate.Requests;

public class CreateFlightRequest(FlightDto flight)
{
    public FlightDto Flight { get; private set; } = flight;
}