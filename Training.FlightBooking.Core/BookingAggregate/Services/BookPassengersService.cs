using AutoMapper;
using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Validations;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class BookPassengersService(
    IBookingRepository bookingRepository,
    IMapper mapper,
    ILogger logger,
    IEnumerable<IBookPassengerValidationRule> rules) : IBookPassengersService
{
    public async Task<Result<Guid>> BookPassengers(BookPassengersRequest request, CancellationToken token)
    {
        try
        {
            var booking = new Booking(request.FlightId, request.Seats);
            booking.AddPassenger(request.PassengerId);

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
        catch (ArgumentException ex)
        {
            var validationFailures = new List<ValidationFailure>
                { new(nameof(Booking), ex.Message) };
            return Result<Guid>.Failure(validationFailures);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. Request: {@Request}", nameof(BookPassengersService), request);

            var validationFailures = new List<ValidationFailure>
                { new(nameof(Booking), "Something went wrong.") };

            return Result<Guid>.Failure(validationFailures);
        }
    }
}