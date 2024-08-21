using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class CancelBookingService(IRepository<Booking> repository) : ICancelBookingService
{

    public async Task<Result> CancelBookingStatus(Guid id, CancellationToken cancellationToken)
    {
        var booking = await repository.GetByIdAsync(id, cancellationToken);
        if (booking is null)
        {
            return Result.Failure(
                new List<ValidationFailure>() { new (nameof(Booking), "Booking not found") });
        }
            
        
        booking.CancelBooking();
        return Result.Success();
    }
}