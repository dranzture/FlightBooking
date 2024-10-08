﻿using FluentValidation.Results;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;

public interface IBookPassengerValidationRule
{
    Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token);
}