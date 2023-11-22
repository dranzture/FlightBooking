using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.BookingAggregate;
using Training.IntegrationTest.Core.BookingAggregate.Interfaces;
using Training.IntegrationTest.Core.BookingAggregate.Specifications;

namespace Training.IntegrationTest.Core.Services;

public class CreateBookingService(IRepository<Booking> repository) : ICreateBookingService
{
    public async Task<Booking> CreateBooking(Booking item, CancellationToken token)
    {
        var booking = await repository.FirstOrDefaultAsync(new GetOpenBookingByFlightId(item.Flight.Id), token);
        if (booking is not null) throw new ArgumentException("Booking for this flight already exists.");

        await repository.AddAsync(item, token);
        await repository.SaveChangesAsync(token);
        return item;
    }
}