using Ardalis.SmartEnum;

namespace Training.FlightBooking.Core.FlightAggregate;

public class ObserveFlightAvailability : SmartEnum<ObserveFlightAvailability>
{
    
    public static readonly ObserveFlightAvailability Increase = new (nameof(Increase), 0);
    public static readonly ObserveFlightAvailability Decrease = new (nameof(Decrease), 1);
    
    private ObserveFlightAvailability(string name, int value) : base(name, value)
    {
    }
}