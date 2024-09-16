using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.FlightBooking.Core.ValueObjects;

[ComplexType]
public class Location
{
    public Location(string state, string city)
    {
        State = state;
        City = city;
    }
    public Location(){}
    public string State { get; private set; }
    public string City { get; private set; }
}