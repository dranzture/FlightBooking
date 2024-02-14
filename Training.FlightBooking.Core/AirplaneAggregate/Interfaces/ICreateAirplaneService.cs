namespace Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

public interface ICreateAirplaneService
{
    Task<Guid> CreateAirplane(Airplane airplane, CancellationToken cancellationToken);
}