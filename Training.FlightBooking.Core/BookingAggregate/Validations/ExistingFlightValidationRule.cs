using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Validations;

public class ExistingFlightValidationRule(IRepository<Flight> repository) : IBookPassengerValidationRule
{
    public async Task<ValidationFailure?> ValidateAsync(Booking booking, CancellationToken token)
    {
        var flightNoTrack = new GetFlightById(booking.FlightId);

        var flight = await repository.FirstOrDefaultAsync(flightNoTrack, token);
        return flight is null ? new ValidationFailure(nameof(Flight), "Flight not found") : null;
    }
}