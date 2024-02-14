using Ardalis.SharedKernel;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class PassengerDto : BaseDto<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }

    public PassengerDto(string firstName, string lastName, string email, DateOnly dateOfBirth, string? phoneNumber = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
    }
    public PassengerDto(){}
}