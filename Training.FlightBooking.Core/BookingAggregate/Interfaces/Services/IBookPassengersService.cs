using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface IBookPassengersService
{
    Task<Result<Guid>> BookPassengers(BookPassengersRequest request, CancellationToken token);
}