namespace Training.FlightBooking.Core.DTOs;

public class LocationDto(string state, string city)
{
    public string? State { get; private set; } = state;
    public string? City { get; private set; } = city;
}