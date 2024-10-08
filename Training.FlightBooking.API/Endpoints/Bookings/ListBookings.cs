﻿using FastEndpoints;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.API.Endpoints.Bookings;

public class ListBookings(IListBookingsService service)
    : EndpointWithoutRequest<Result<IEnumerable<BookingDto>>>
{
    private const string Route = "api/Bookings/List";

    public override void Configure()
    {
        Get(Route);
        AllowAnonymous();
        Summary(s => { s.Description = "Retrieves all bookings."; });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var bookings = await service.ListBookings(ct);
        await SendOkAsync(bookings, ct);
    }
}