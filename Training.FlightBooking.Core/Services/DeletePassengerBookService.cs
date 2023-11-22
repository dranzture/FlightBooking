using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.BookingAggregate;
using Training.IntegrationTest.Core.BookingAggregate.Interfaces;
using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.Services;

public class DeletePassengerBookService(IRepository<Booking> repository) : IDeletePassengerBookService
{
    public async Task DeletePassengerBooking(Guid bookingId, List<Passenger> passengers, CancellationToken token)
    {
        var booking = await repository.GetByIdAsync(bookingId, token);
        if (booking is null) throw new ArgumentException("Booking not found");
        
        booking.RemovePassengers(passengers.ToHashSet());
        await repository.SaveChangesAsync(token);
    }
}