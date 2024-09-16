using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface ICancelBookingService
{
    Task<Result> CancelBookingStatus(Guid id, CancellationToken cancellationToken);
}