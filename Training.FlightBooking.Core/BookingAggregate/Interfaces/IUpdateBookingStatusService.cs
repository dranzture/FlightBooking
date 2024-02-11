using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IUpdateBookingStatusService
{
    Task UpdateBookingStatus(Flight flight, BookingStatus status, CancellationToken cancellationToken);
}