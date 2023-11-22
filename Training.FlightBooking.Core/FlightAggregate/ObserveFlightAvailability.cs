using Ardalis.SmartEnum;

namespace Training.IntegrationTest.Core.FlightAggregate;

public class ObserveFlightAvailability : SmartEnum<ObserveFlightAvailability>
{
    
    public static readonly ObserveFlightAvailability Increase = new ObserveFlightAvailability(nameof(Increase), 0);
    public static readonly ObserveFlightAvailability Decrease = new ObserveFlightAvailability(nameof(Decrease), 1);
    
    private ObserveFlightAvailability(string name, int value) : base(name, value)
    {
    }
}