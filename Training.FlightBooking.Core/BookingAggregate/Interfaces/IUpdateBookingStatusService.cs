using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface ICancelBookingService
{
    Task<Result> CancelBookingStatus(Guid id, CancellationToken cancellationToken);
}