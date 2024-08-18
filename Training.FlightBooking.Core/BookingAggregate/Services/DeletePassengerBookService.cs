using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class DeletePassengerBookService(IRepository<Booking> repository) : IDeletePassengerBookService
{
    public async Task DeletePassengerBooking(Guid bookingId, CancellationToken token)
    {
        var booking = await repository.GetByIdAsync(bookingId, token);
        if (booking is null) throw new ArgumentException("Booking not found");
        
        booking.CancelBooking();
        await repository.UpdateAsync(booking, token);
    }
}