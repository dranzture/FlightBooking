using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.BookingAggregate;
using Training.IntegrationTest.Core.BookingAggregate.Interfaces;
using Training.IntegrationTest.Core.BookingAggregate.Specifications;
using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.Services;

public class BookPassengerService(IRepository<Booking> repository) : IBookPassengerService
{
    public async Task BookPassenger(Guid flightId, List<Passenger> passengers, CancellationToken token)
    {
        var booking = await repository.FirstOrDefaultAsync(new GetOpenBookingByFlightId(flightId), token);
        if (booking is null) throw new ArgumentException("Booking not found");
        
        booking.AddPassengers(passengers.ToHashSet());
        await repository.SaveChangesAsync(token);
    }
}