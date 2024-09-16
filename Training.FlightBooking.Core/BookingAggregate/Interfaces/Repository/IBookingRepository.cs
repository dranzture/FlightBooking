namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;

public interface IBookingRepository
{
    Task AddAsync(Booking booking, CancellationToken cancellationToken);
    
    Task UpdateAsync(Booking booking, CancellationToken cancellationToken);

}