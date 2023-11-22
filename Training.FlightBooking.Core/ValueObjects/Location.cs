using System.ComponentModel.DataAnnotations.Schema;

namespace Training.IntegrationTest.Core.ValueObjects;

[ComplexType]
public class Location
{
    public Location(string state, string city)
    {
        State = state;
        City = city;
    }
    public Location(){}
    public string? State { get; set; }
    public string? City { get; set; }
}