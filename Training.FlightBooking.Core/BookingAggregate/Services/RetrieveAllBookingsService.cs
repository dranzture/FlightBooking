using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class RetrieveAllBookingsService(IRepository<Booking> repository) : IRetrieveAllBookingsService
{
    public async Task<IEnumerable<Booking>> GetAllBookings(CancellationToken token)
    {
        return await repository.ListAsync(token);
    }
}