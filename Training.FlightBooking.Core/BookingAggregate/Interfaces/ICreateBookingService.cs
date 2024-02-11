using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.BookingAggregate.Responses;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface ICreateBookingService
{
    Task<CreateBookingResponse> CreateBooking(CreateBookingRequest bookingRequest, CancellationToken token = default);
}