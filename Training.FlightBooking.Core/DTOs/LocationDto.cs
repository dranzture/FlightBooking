namespace Training.FlightBooking.Core.DTOs;

public class LocationDto(string state, string city)
{
    public string? State { get; set; } = state;
    public string? City { get; set; } = city;
}