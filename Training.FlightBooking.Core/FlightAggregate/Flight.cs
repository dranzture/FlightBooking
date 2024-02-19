using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate.Events;
using Training.FlightBooking.Core.ValueObjects;

namespace Training.FlightBooking.Core.FlightAggregate;

public class Flight : Shared.EntityBase<Guid>, IAggregateRoot
{
    public Flight()
    {
    }

    public Flight(Guid airplaneId, int availableSeats, DateTime arrival, DateTime departure, Location from, Location to)
    {
        To = to;
        From = from;
        Arrival = Guard.Against.OutOfSQLDateRange(arrival);
        Departure = Guard.Against.OutOfSQLDateRange(departure);
        Seats = availableSeats;
        BookedSeats = 0;
        AirplaneId = airplaneId;

        RegisterDomainEvent(new FlightCreated(this));
    }

    public Location To { get; private set; }

    public Location From { get; private set; }

    public DateTime Arrival { get; private set; }

    public DateTime Departure { get; private set; }

    public int Seats { get; private set; }

    public int BookedSeats { get; private set; }


    public Airplane Airplane { get; private set; }

    public Guid AirplaneId { get; private set; }

    public FlightStatus Status { get; private set; } = FlightStatus.OnTime;


    public void UpdateStatus(FlightStatus status)
    {
        Status = status;
    }

    public void UpdateArrivalDateTime(DateTime arrival)
    {
        if (arrival > Departure)
        {
            throw new ArgumentException("Arrival time cannot be before departure time");
        }

        Arrival = Guard.Against.OutOfSQLDateRange(arrival);
    }

    public void UpdateDepartureDateTime(DateTime departure)
    {
        if (departure <= Arrival)
        {
            throw new ArgumentException("Departure time cannot be after arrival time");
        }

        Departure = Guard.Against.OutOfSQLDateRange(departure);
    }

    public void IncreaseSeatAvailability(int occupiedSeats)
    {
        if (Seats - BookedSeats < occupiedSeats)
        {
            throw new ArgumentException("Cannot increase seat availability due to capacity limit");
        }

        BookedSeats -= occupiedSeats;
    }

    public void DecreaseSeatAvailability(int occupiedSeats)
    {
        if (BookedSeats + occupiedSeats > Seats)
        {
            throw new ArgumentException("More seats have been requested to remove than booked seats");
        }

        BookedSeats += occupiedSeats;
    }
}