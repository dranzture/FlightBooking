using Microsoft.Extensions.Caching.Memory;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;

namespace Training.FlightBooking.Data.Repositories.FlightRepositories;

public class CachedFlightRepository(FlightRepository flightRepository, IMemoryCache memoryCache) : IFlightRepository
{
    public Task<Flight> AddAsync(Flight flight, CancellationToken cancellationToken = default)
    {
        return flightRepository.AddAsync(flight, cancellationToken);
    }

    public Task UpdateAsync(Flight flight, CancellationToken cancellationToken = default)
    {
        return flightRepository.UpdateAsync(flight, cancellationToken);
    }

    public Task<Flight?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var key = $"Flight-{id}";
        return memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return flightRepository.GetByIdAsync(id, cancellationToken);
            });
    }

    public Task<List<Flight>> ListAsync(CancellationToken cancellationToken = default)
    {
        return flightRepository.ListAsync(cancellationToken);
    }

    public Task<List<Flight>> ListByAirplaneIdAsync(Guid airplaneId, CancellationToken cancellationToken = default)
    {
        return flightRepository.ListByAirplaneIdAsync(airplaneId, cancellationToken);
    }
}