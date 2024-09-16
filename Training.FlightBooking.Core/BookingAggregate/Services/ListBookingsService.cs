using Ardalis.SharedKernel;
using AutoMapper;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Services;

public class ListBookingsService(IBookingRepository repository, IMapper mapper) : IListBookingsService
{
    public async Task<Result<IEnumerable<BookingDto>>> ListBookings(CancellationToken token)
    {
        var result = await repository.ListAsync(token);
        
        return Result<IEnumerable<BookingDto>>.Success(mapper.Map<IEnumerable<BookingDto>>(result));
    }
} 