using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate;

namespace Training.FlightBooking.Core.PassengerAggregate;

public class Passenger : Shared.EntityBase<Guid>, IAggregateRoot
{
    public Passenger(){}
    
    public Passenger(string firstName, string lastName, string email, DateOnly dateOfBirth)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName);
        LastName = Guard.Against.NullOrEmpty(lastName);
        Email = ValidateEmail(email);
        DateOfBirth = dateOfBirth;
        Id = Guid.NewGuid();
    }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateOnly DateOfBirth { get; private set; }

    private List<Booking> _bookings = new();
    
    public IReadOnlyCollection<Booking> Bookings  => _bookings;

    private string ValidateEmail(string email)
    {
        Guard.Against.InvalidFormat(email, nameof(email),@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$","Invalid email format");
        return email;
    }

    public void UpdateEmail(string email)
    {
        Email = ValidateEmail(email);
    }
    
}