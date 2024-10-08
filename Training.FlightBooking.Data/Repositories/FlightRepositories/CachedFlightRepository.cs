using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Data.Data;
using Training.FlightBooking.Data.Helpers;

namespace Training.FlightBooking.Data.Repositories.FlightRepositories;

public class CachedFlightRepository(
    FlightRepository flightRepository,
    IDistributedCache distributedCache,
    AppDbContext dbContext) : IFlightRepository
{
    public Task<Flight> AddAsync(Flight flight, CancellationToken cancellationToken = default)
    {
        return flightRepository.AddAsync(flight, cancellationToken);
    }

    public Task UpdateAsync(Flight flight, CancellationToken cancellationToken = default)
    {
        return flightRepository.UpdateAsync(flight, cancellationToken);
    }

    public async Task<Flight?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var key = $"Flight-{id}";

        var cachedFlightString = await distributedCache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrEmpty(cachedFlightString))
        {
            var flight = await flightRepository.GetByIdAsync(id, cancellationToken);
            if (flight is null) return null;

            await distributedCache.SetStringAsync(key,
                JsonConvert.SerializeObject(flight),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2)
                }, cancellationToken);

            return flight;
        }

        var cachedFlight = JsonConvert.DeserializeObject<Flight>(cachedFlightString, new JsonSerializerSettings
        {
            ConstructorHandling =
                ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new PrivateResolver()
        });
        
        if (cachedFlight is not null)
        {
            dbContext.Set<Flight>().Attach(cachedFlight);
        }

        return cachedFlight;
    }

    public async Task<List<Flight>> ListAsync(CancellationToken cancellationToken = default)
    {
        const string key = "FlightsList";
        var cachedFlightsString = await distributedCache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrEmpty(cachedFlightsString))
        {
            var flights = await flightRepository.ListAsync(cancellationToken);

            await distributedCache.SetStringAsync(key,
                JsonConvert.SerializeObject(flights),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2)
                }, cancellationToken);

            return flights;
        }

        var cachedFlights = JsonConvert.DeserializeObject<List<Flight>>(cachedFlightsString, new JsonSerializerSettings
        {
            ConstructorHandling =
                ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new PrivateResolver()
        });
        return cachedFlights ?? [];
    }

    public Task<List<Flight>> ListByAirplaneIdAsync(Guid airplaneId, CancellationToken cancellationToken = default)
    {
        return flightRepository.ListByAirplaneIdAsync(airplaneId, cancellationToken);
    }
}