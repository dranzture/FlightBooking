using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Events;
using Training.FlightBooking.Core.ValueObjects;

namespace Training.FlightBooking.Core.FlightAggregate;

public class Flight
    : EntityBase<Guid>, IAggregateRoot
{
    public Flight(){}

    public Flight(Airplane plane, DateTime arrival, DateTime departure, Location from, Location to)
    {
        To = to;
        From = from;
        Arrival = Guard.Against.OutOfSQLDateRange(arrival);
        Departure = Guard.Against.OutOfSQLDateRange(departure);
        AvailableSeats = plane.Capacity;
        Plane = plane;
    }
    public Location To { get; private set; }

    public Location From { get; private set; }

    public DateTime Arrival { get; private set; }

    public DateTime Departure { get; private set; }

    public int AvailableSeats { get; private set; }

    public Airplane Plane { get; private set; }

    public FlightStatus Status { get; private set; } = FlightStatus.OnTime;

    public void RegisterFlightCreated()
    {
        RegisterDomainEvent(new FlightCreated(this));
    }

    public void UpdateStatus(FlightStatus status)
    {
        Status = status;
    }

    public void UpdateArrivalDateTime(DateTime arrival)
    {
        if (arrival <= Departure)
        {
            throw new ArgumentException("Arrival time cannot be before departure time");
        }

        Arrival = Guard.Against.OutOfSQLDateRange(arrival);
    }
    
    public void UpdateDepartureDateTime(DateTime departure)
    {
        if (departure >= Arrival)
        {
            throw new ArgumentException("Departure time cannot be after arrival time");
        }

        Departure = Guard.Against.OutOfSQLDateRange(departure);
    }

    public void UpdateSeatAvailability(int seats, ObserveFlightAvailability observe)
    {
        switch (observe)
        {
            case var observeType when observeType == ObserveFlightAvailability.Increase:
                if (AvailableSeats + seats > AvailableSeats) // Assuming MaxCapacity is defined elsewhere
                {
                    throw new ArgumentException("Cannot increase seat availability due to capacity limit");
                }
                AvailableSeats += seats;
                break;
            case var observeType when observeType == ObserveFlightAvailability.Decrease:
                if (AvailableSeats - seats < 0)
                {
                    throw new ArgumentException("Cannot decrease seat availability due to inadequate seats");
                }
                AvailableSeats -= seats;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(observe), "Unknown flight availability operation");
        }

    }
}