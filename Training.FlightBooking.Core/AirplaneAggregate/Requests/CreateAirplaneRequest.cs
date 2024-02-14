using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.AirplaneAggregate.Requests;

public class CreateAirplaneRequest(AirplaneDto airplane)
{
    public AirplaneDto Airplane { get; set; } = airplane;
}