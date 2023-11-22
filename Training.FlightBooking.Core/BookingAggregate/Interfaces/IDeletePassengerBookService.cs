using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.BookingAggregate.Interfaces;

public interface IDeletePassengerBookService
{
    public Task DeletePassengerBooking(Guid bookingId, List<Passenger> passengers, CancellationToken token);
}