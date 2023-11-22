using Ardalis.SmartEnum;

namespace Training.IntegrationTest.Core.FlightAggregate;

public class FlightStatus : SmartEnum<FlightStatus>
{
    public static readonly FlightStatus OnTime = new(nameof(OnTime), 0);
    public static readonly FlightStatus Delayed = new(nameof(Delayed), 1);
    public static readonly FlightStatus Canceled = new(nameof(Canceled), 2);
    public static readonly FlightStatus ReadyToDepart = new(nameof(ReadyToDepart), 3);
    public static readonly FlightStatus Departed = new(nameof(Departed), 4);
    public static readonly FlightStatus Arrived = new(nameof(Arrived), 5);
    
    /// <summary>
    /// Initializes a new instance of the FlightStatus class.
    /// </summary>
    /// <param name="name">The name of the flight status.</param>
    /// <param name="value">The value of the flight status.</param>
    private FlightStatus(string name, int value) : base(name, value) { }
}