namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IRetrieveAllBookingsService
{
    Task<IEnumerable<Booking>> GetAllBookings(CancellationToken token = default);
}