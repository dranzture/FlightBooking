using Ardalis.SmartEnum;

namespace Training.FlightBooking.Core.BookingAggregate;

public class BookingStatus : SmartEnum<BookingStatus>
{
    
    public static readonly BookingStatus Active = new(nameof(Active), 0);
    public static readonly BookingStatus Canceled = new(nameof(Canceled), 1);
    
    
    private BookingStatus(string name, int value) : base(name, value)
    {
    }
    
}