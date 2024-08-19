using Ardalis.SharedKernel;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class PassengerDto : BaseDto<Guid>
{
    public PassengerDto()
    {
    }
    public PassengerDto(string firstName,
        string lastName,
        string email,
        DateOnly dateOfBirth,
        string? phoneNumber = null)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string Email { get; private set; }
    public string? PhoneNumber { get; private set; }
}