using FluentValidation.Results;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;

public interface IDeletePassengerValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token);
}