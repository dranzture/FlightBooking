using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IDeletePassengerBookService
{
    public Task DeletePassengerBooking(Guid bookingId,CancellationToken token);
}