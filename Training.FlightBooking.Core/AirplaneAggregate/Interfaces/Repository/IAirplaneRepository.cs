namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;

public interface IAirplaneRepository
{
    Task<Airplane> AddAsync(Airplane airplane, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Airplane airplane, CancellationToken cancellationToken = default);
    
    Task<Airplane?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Airplane?> FindByModelManufacturerAndYear(string model, string manufacturer, int year, CancellationToken cancellationToken = default);
    
    Task<List<Airplane>> ListAsync(CancellationToken cancellationToken = default);
}