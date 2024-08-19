namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface ICreateAirplaneService
{
    Task<Guid> CreateAirplaneAsync(Airplane airplane, CancellationToken cancellationToken);
}