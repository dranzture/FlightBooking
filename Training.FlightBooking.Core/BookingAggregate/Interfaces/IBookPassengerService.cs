using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.BookingAggregate.Interfaces;

public interface IBookPassengerService
{
    public Task BookPassenger(Guid flightId, List<Passenger> passengers, CancellationToken token);
}