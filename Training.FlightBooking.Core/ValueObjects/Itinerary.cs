namespace Training.FlightBooking.Core.ValueObjects;

public class Itinerary(
    string firstName,
    string lastName,
    string email,
    string? phoneNumber = null)
{
    public string FirstName { get; private set; } = firstName;

    public string LastName { get; private set; } = lastName;

    public string Email { get; private set; } = email;

    public string? PhoneNumber { get; private set; } = phoneNumber;
}
    
