using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.PassengerAggregate;

public class Passenger : Shared.EntityBase<Guid>, IAggregateRoot
{
    public Passenger()
    {
    }

    public Passenger(string firstName, string lastName, string email, DateOnly dateOfBirth)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName);
        LastName = Guard.Against.NullOrEmpty(lastName);
        Email = Guard.Against.InvalidInput(email, nameof(email), FormatHelper.ValidateEmail, "Invalid email format");
        DateOfBirth = dateOfBirth;
        Id = Guid.NewGuid();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateOnly DateOfBirth { get; private set; }

    private List<Booking> _bookings = new();

    public IReadOnlyCollection<Booking> Bookings => _bookings;


    public void UpdateEmail(string email)
    {
        Guard.Against.InvalidInput(email, nameof(email), FormatHelper.ValidateEmail, "Invalid email format");
        Email = email;
    }
}