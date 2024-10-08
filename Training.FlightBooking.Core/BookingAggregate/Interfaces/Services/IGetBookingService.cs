﻿using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface IGetBookingService
{
    Task<Result<BookingDto>> GetBookingByIdAsync(Guid id, CancellationToken cancellationToken);
}