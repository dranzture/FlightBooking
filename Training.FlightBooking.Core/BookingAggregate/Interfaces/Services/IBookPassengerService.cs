using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IBookPassengerService
{
    public Task<Result<Guid>> BookPassenger(Guid flightId, Guid passengerId, int seats, CancellationToken token);
}