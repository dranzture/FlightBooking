namespace Training.IntegrationTest.Core.BookingAggregate.Interfaces;

public interface ICreateBookingService
{
    Task<Booking> CreateBooking(Booking booking, CancellationToken token);
}