namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;

public interface IBookingRepository
{
    Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken);
    
    Task UpdateAsync(Booking booking, CancellationToken cancellationToken);
    
    Task DeleteAsync(Booking booking, CancellationToken cancellationToken);

    Task<List<Booking>> ListAsync(CancellationToken cancellationToken);
    
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Booking?> GetByFlightIdAndPassengerId(Booking booking, CancellationToken cancellationToken);
}