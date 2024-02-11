using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class AirplaneDto : BaseDto<Guid>
{
    public AirplaneDto(Guid id, string model, string manufacturer, int capacity, int year)
    {
        Id = id;
        Model = model;
        Manufacturer = manufacturer;
        Capacity = capacity;
        Year = year;
    }

    public int Year { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Capacity { get; set; }
}