using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Specifications;

namespace Training.FlightBooking.Core.BookingAggregate.Validations;

public class UniquePassengerBookingValidationRule(IRepository<Booking> repository) : IBookPassengerValidationRule
{
    public async Task ValidateAsync(Booking booking, CancellationToken token)
    {
        var spec = new FindByFlightIdAndPassengerId(booking.FlightId, booking.PassengerId);
        var existingBooking = await repository.FirstOrDefaultAsync(spec, token);
        if (existingBooking != null)
        {
            throw new InvalidOperationException("This passenger already has a booking for this flight.");
        }
    }
}