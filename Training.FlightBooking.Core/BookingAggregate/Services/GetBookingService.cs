using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class GetBookingService(IRepository<Booking> repository, IMapper mapper) : IGetBookingService
{
    public async Task<Result<BookingDto>> GetBookingByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await repository
            .GetByIdAsync(id, cancellationToken);

        return result is null
            ? Result<BookingDto>.Failure([new ValidationFailure(nameof(Booking), "Booking not found")])
            : Result<BookingDto>.Success(mapper.Map<BookingDto>(result));
    }
}