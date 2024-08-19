using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Requests;

public class UpdateAirplaneRequest(string model, string manufacturer, int year) : BaseDto<Guid>
{
    public string Model { get; set; } = model;
    public string Manufacturer { get; set; } = manufacturer;
    public int Year { get; set; } = year;
}