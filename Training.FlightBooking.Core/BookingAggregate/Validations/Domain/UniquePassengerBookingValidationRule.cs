using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Specifications;

namespace Training.FlightBooking.Core.BookingAggregate.Validations.Domain;

public class UniquePassengerBookingValidationRule(IRepository<Booking> repository) : IBookPassengerValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token)
    {
        var spec = new FindByFlightIdAndPassengerId(booking.FlightId, booking.PassengerId);
        var existingBooking = await repository.FirstOrDefaultAsync(spec, token);
        return existingBooking is not null
            ? new ValidationFailure(nameof(Booking), "Passenger has already booked flight")
            : null;
    }
}