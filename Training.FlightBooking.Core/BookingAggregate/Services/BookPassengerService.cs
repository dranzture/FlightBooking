using Ardalis.SharedKernel;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class BookPassengerService(
    IRepository<Booking> bookingRepository,
    IEnumerable<IBookPassengerValidationRule> rules) : IBookPassengerService
{
    public async Task<Result<Guid>> BookPassenger(Guid flightId, Guid passengerId, int seats, CancellationToken token)
    {
        var booking = new Booking(flightId, seats);
        booking.AddPassenger(passengerId);
        
        var validationFailures = new List<ValidationFailure>();
        
        foreach (var rule in rules)
        {
            var validationFailure = await rule.ValidateAsync(booking, token);
            if (validationFailure is not null)
            {
                validationFailures.Add(validationFailure);
            }
        }
        
        if (validationFailures.Count > 0)
        {
            return Result<Guid>.Failure(validationFailures);
        }
        
        var result = await bookingRepository.AddAsync(booking, token);
        return Result<Guid>.Success(result.Id);
    }
}