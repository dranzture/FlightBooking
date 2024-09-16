using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface IListBookingsService
{
    Task<Result<IEnumerable<BookingDto>>> ListBookings(CancellationToken token = default);
}