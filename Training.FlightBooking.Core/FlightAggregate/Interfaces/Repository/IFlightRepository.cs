namespace Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;

public interface IFlightRepository
{
    Task<Flight> AddAsync(Flight flight, CancellationToken cancellationToken = default);

    Task UpdateAsync(Flight flight, CancellationToken cancellationToken = default);

    Task<Flight?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Flight>> ListAsync(CancellationToken cancellationToken = default);

    Task<List<Flight>> ListByAirplaneIdAsync(Guid airplaneId, CancellationToken cancellationToken = default);
}