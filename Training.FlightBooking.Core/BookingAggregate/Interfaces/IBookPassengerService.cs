using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IBookPassengerService
{
    public Task<Guid> BookPassenger(Guid flightId, Guid passengerId, int seats, CancellationToken token);
}