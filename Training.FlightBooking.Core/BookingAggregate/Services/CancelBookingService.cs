﻿using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class CancelBookingService(IBookingRepository repository, 
    ILogger logger, 
    IEnumerable<ICancelBookingValidationRule> rules)
    : ICancelBookingService
{
    public async Task<Result> CancelBookingStatus(CancelBookingRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var booking = new Booking(request.Id);
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
        catch (ArgumentException ex)
        {
            var validationFailures = new List<ValidationFailure>
                { new(nameof(Booking), ex.Message) };
            return Result.Failure(validationFailures);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. Request: {@Request}", nameof(CancelBookingService), request);

            var validationFailures = new List<ValidationFailure>
                { new(nameof(Booking), "Something went wrong.") };

            return Result.Failure(validationFailures);
        }
    }
}