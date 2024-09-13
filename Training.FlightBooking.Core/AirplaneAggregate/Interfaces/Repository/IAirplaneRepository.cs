namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;

public interface IAirplaneRepository
{
    Task AddAsync(Airplane airplane, CancellationToken cancellationToken);
    
    Task UpdateAsync(Airplane airplane, CancellationToken cancellationToken);
    
    Task<Airplane?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Airplane?> FindByModelManufacturerAndYear(string model, string manufacturer, int year, CancellationToken cancellationToken);
    
    Task<List<Airplane>> ListAsync(CancellationToken cancellationToken);
}