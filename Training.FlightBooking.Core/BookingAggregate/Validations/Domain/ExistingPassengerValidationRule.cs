using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;

namespace Training.FlightBooking.Core.BookingAggregate.Validations.Domain;

public class ExistingPassengerValidationRule(IBookingRepository repository) : IBookPassengerValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token)
    {
        var passenger = await repository.GetByFlightIdAndPassengerId(booking, token);
        return passenger is not null
            ? new ValidationFailure(nameof(Booking), "Passenger has already booked this flight.")
            : null;
    }
}