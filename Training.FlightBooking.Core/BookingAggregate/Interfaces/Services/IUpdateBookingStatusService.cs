﻿using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface ICancelBookingService
{
    Task<Result> CancelBookingStatus(CancelBookingRequest request, CancellationToken cancellationToken);
}