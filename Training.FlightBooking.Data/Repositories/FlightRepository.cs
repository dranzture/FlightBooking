using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Data.Repositories.Specifications.Flight;

namespace Training.FlightBooking.Data.Repositories;

public class FlightRepository(IRepository<Flight> repository) : IFlightRepository
{
    public Task<Flight> AddAsync(Flight flight, CancellationToken cancellationToken)
    {
        return repository.AddAsync(flight, cancellationToken);
    }

    public Task UpdateAsync(Flight flight, CancellationToken cancellationToken)
    {
        return repository.UpdateAsync(flight, cancellationToken);
    }

    public Task<Flight?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(id, cancellationToken);
    }

    public Task<List<Flight>> ListAsync(CancellationToken cancellationToken)
    {
        return repository.ListAsync(cancellationToken);
    }

    public Task<List<Flight>> ListByAirplaneIdAsync(Guid airplaneId, CancellationToken cancellationToken)
    {
        var flightsByAirplane = new GetFlightsByAirplaneId(airplaneId);
        return repository.ListAsync(flightsByAirplane, cancellationToken);
    }
}