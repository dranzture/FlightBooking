using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Specifications;

namespace Training.FlightBooking.Core.BookingAggregate.Validations;

public class ExistingPassengerValidationRule(IRepository<Booking> repository) : IBookPassengerValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token)
    {
        var passengerNoTrack = new FindByFlightIdAndPassengerId(booking.FlightId, booking.PassengerId);
        var passenger = await repository.FirstOrDefaultAsync(passengerNoTrack, token);
        return passenger is not null
            ? new ValidationFailure(nameof(Booking), "Passenger has already booked flight")
            : null;
    }
}