using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;

namespace Training.FlightBooking.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    public Task AddAsync(Booking booking, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Booking booking, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}