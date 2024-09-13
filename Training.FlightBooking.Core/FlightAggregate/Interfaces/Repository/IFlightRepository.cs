namespace Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;

public interface IFlightRepository
{
    Task<Flight> AddAsync(Flight flight, CancellationToken cancellationToken);

    Task UpdateAsync(Flight flight, CancellationToken cancellationToken);

    Task<Flight?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Flight>> ListAsync(CancellationToken cancellationToken);

    Task<List<Flight>> ListByAirplaneIdAsync(Guid airplaneId, CancellationToken cancellationToken);
}