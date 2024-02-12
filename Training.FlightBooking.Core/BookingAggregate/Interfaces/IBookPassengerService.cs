using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Interfaces;

public interface IBookPassengerService
{
    public Task BookPassenger(Guid flightId, Passenger passenger, int seats, CancellationToken token);
}