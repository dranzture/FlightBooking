namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IBookPassengerValidationRule
{
    Task ValidateAsync(Booking booking, CancellationToken token);
}