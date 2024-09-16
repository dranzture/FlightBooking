using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class CancelBookingService(IBookingRepository repository, IEnumerable<ICancelBookingValidationRule> rules) : ICancelBookingService
{

    public async Task<Result> CancelBookingStatus(Guid id, CancellationToken cancellationToken)
    {
        var booking = new Booking(id);
        var validationFailures = new List<ValidationFailure>();
        
        foreach (var rule in rules)
        {
            var validationFailure = await rule.ValidateAsync(booking, cancellationToken);
            if (validationFailure is not null)
            {
                validationFailures.Add(validationFailure);
            }
        }
        
        if (validationFailures.Count > 0)
        {
            return Result<Guid>.Failure(validationFailures);
        }
            
        
        booking.CancelBooking();
        await repository.UpdateAsync(booking, cancellationToken);
        return Result.Success();
    }
}