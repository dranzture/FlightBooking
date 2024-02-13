using Ardalis.SharedKernel;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.DTOs;

public class PassengerDto(
    string firstName,
    string lastName,
    string email,
    DateTime dateOfBirth,
    string? phoneNumber = null) : BaseDto<Guid>
{
    public string FirstName { get; private set; } = firstName;

    public string LastName { get; private set; } = lastName;

    public DateTime DateOfBirth { get; private set; } = dateOfBirth;

    public string Email { get; private set; } = email;

    public string? PhoneNumber { get; private set; } = phoneNumber;
}