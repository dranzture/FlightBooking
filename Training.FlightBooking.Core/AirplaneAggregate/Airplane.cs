using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Training.FlightBooking.Core.AirplaneAggregate;

public class Airplane : Shared.EntityBase<Guid>, IAggregateRoot
{
    public Airplane(){}
    /// <summary>
    /// Initializes a new instance of the Airplane class.
    /// </summary>
    /// <param name="model">The model of the airplane.</param>
    /// <param name="manufacturer">The manufacturer of the airplane.</param>
    /// <param name="capacity">The capacity of the airplane.</param>
    /// <param name="year">The year of the airplane manufactured.</param>
    public Airplane(string model, string manufacturer, int capacity, int year)
    {
        Year = Guard.Against.Negative(year, nameof(year));
        Model = Guard.Against.NullOrEmpty(model);
        Manufacturer = Guard.Against.NullOrEmpty(manufacturer);
        Capacity = Guard.Against.Negative(capacity);
        Id = Guid.NewGuid();
    }
    
    public int Year { get; private set; }

    public string Model { get; private set; }
    
    public string Manufacturer { get; private set; }
    
    public int Capacity { get; private set; }

    /// <summary>
    /// Updates the capacity of the object.
    /// </summary>
    /// <param name="capacity">The new capacity value.</param>
    /// <exception cref="ArgumentException">Thrown when the capacity is negative.</exception>
    public void UpdateCapacity(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException("Capacity cannot be negative");
        }
        Capacity = capacity;
    }
    
    public void UpdateYear(int year)
    {
        if (year < 0)
        {
            throw new ArgumentException("Year cannot be negative");
        }
        Year = year;
    }
    
    public void UpdateModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Model cannot be empty");
        }
        Model = model;
    }
    
    public void UpdateManufacturer(string manufacturer)
    {
        if (string.IsNullOrWhiteSpace(manufacturer))
        {
            throw new ArgumentException("Manufacturer cannot be empty");
        }
        Manufacturer = manufacturer;
    }
}