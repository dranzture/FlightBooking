using System.Data;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.ValueObjects;

namespace Training.IntegrationTest.Core.FlightAggregate;

public class Flight(Airplane plane, DateTime departure, DateTime arrival, Location from, Location to)
    : EntityBase<Guid>, IAggregateRoot
{
    public Location To { get; private set; } = to;

    public Location From { get; private set; } = from;

    public DateTime Arrival { get; private set; } = Guard.Against.OutOfSQLDateRange(arrival);

    public DateTime Departure { get; private set; } = Guard.Against.OutOfSQLDateRange(departure);

    public int AvailableSeats { get; private set; } = plane.Capacity;

    public Airplane Plane { get; private set; } = Guard.Against.Null<Airplane>(plane);

    public FlightStatus Status { get; private set; } = FlightStatus.OnTime;

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
        if (observe == ObserveFlightAvailability.Increase)
        {
            if (AvailableSeats < AvailableSeats + seats)
                throw new ArgumentException("Cannot increase seat availability due to capacity limit");
            AvailableSeats += seats;
        }
        else if (observe == ObserveFlightAvailability.Decrease)
        {
            if (AvailableSeats - seats < 0)
                throw new ArgumentException("Cannot decrease seat availability due to inadequate seats");
            AvailableSeats -= seats;
            
        }
    }
}