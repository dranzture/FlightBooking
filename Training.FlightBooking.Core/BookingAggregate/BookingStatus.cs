using Ardalis.SmartEnum;

namespace Training.IntegrationTest.Core.BookingAggregate;

public class BookingStatus : SmartEnum<BookingStatus>
{
    
    public static readonly BookingStatus Open = new(nameof(Open), 0);
    public static readonly BookingStatus Closed = new(nameof(Open), 1);
    
    private BookingStatus(string name, int value) : base(name, value)
    {
    }
}