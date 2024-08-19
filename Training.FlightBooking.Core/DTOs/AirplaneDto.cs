using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class AirplaneDto(string model, string manufacturer, int capacity, int year)
    : BaseDto<Guid>
{
    public int Year { get; private set; } = year;
    public string Model { get; private set; } = model;
    public string Manufacturer { get; private set; } = manufacturer;
    public int Capacity { get; private set; } = capacity;
}