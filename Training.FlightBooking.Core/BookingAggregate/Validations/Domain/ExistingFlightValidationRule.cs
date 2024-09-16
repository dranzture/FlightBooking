using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Validations.Domain;

public class ExistingFlightBookingValidationRule(IBookingRepository repository) : 
    IBookPassengerValidationRule,
    ICancelBookingValidationRule, 
    IDeletePassengerBookingValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(booking.FlightId, token);
        return flight is null ? new ValidationFailure(nameof(Flight), "Booking is not found.") : null;
    }
}