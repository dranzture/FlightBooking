using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface IDeletePassengerBookService
{
    public Task<Result> DeletePassengerBooking(Guid bookingId,CancellationToken token);
}