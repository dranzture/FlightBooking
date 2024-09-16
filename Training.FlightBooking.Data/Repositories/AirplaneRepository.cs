using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Data.Repositories.Specifications.Airplane;

namespace Training.FlightBooking.Data.Repositories;

public class AirplaneRepository(IRepository<Airplane> repository) : IAirplaneRepository
{
    public Task<Airplane> AddAsync(Airplane airplane, CancellationToken cancellationToken)
    {
        return repository.AddAsync(airplane, cancellationToken);
    }

    public Task UpdateAsync(Airplane airplane, CancellationToken cancellationToken)
    {
        return repository.UpdateAsync(airplane, cancellationToken);
    }

    public Task<Airplane?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(id, cancellationToken);
    }

    public Task<Airplane?> FindByModelManufacturerAndYear(string model, string manufacturer, int year, CancellationToken cancellationToken)
    {
        var newAirplane = new FindByModelManufacturerAndYear(model, manufacturer, year);
        return repository.FirstOrDefaultAsync(newAirplane, cancellationToken);
    }

    public Task<List<Airplane>> ListAsync(CancellationToken cancellationToken)
    {
        return repository.ListAsync(cancellationToken);
    }
}