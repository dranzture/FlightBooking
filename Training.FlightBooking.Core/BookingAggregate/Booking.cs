using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.BookingAggregate.Events;
using Training.IntegrationTest.Core.FlightAggregate;
using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.BookingAggregate;

public class Booking : EntityBase<Guid>, IAggregateRoot
{
    /// <summary>
    /// Initializes a new instance of the Booking class with the specified flight.
    /// </summary>
    /// <param name="flight">The flight associated with the booking.</param>
    public Booking(Flight flight)
    {
        Flight = flight;
    }
    
    public BookingStatus Status { get; private set; } = BookingStatus.Open;
    
    public Flight Flight { get; private set; }
    
    private HashSet<Passenger> _passengers = new HashSet<Passenger>();
    
    public IReadOnlyCollection<Passenger> Passengers => _passengers;

    public void AddPassengers(HashSet<Passenger> passengers)
    {
        foreach (var passenger in passengers)
        {
            if (_passengers.Contains(passenger))
            {
                throw new AggregateException("Passenger already added to booking");
            }
            
            _passengers.Add(passenger);
        }
        RegisterDomainEvent(new PassengerBookedFlight(Flight.Id, passengers.ToList()));
    }

    public void RemovePassengers(HashSet<Passenger> passengers)
    {
        foreach (var passenger in passengers)
        {
            if (!_passengers.Contains(passenger))
            {
                throw new AggregateException("Passenger does not exist in booking");
            }
            
            _passengers.Remove(passenger);
        }
        RegisterDomainEvent(new PassengerCanceledFlight(Flight.Id, passengers.ToList()));
    }
}