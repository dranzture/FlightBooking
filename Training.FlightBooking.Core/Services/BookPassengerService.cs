using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Specifications;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.Services;

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