using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces.Services;

public interface IBookPassengerService
{
    public Task<Result<Guid>> BookPassenger(Guid flightId, Guid passengerId, int seats, CancellationToken token);
}