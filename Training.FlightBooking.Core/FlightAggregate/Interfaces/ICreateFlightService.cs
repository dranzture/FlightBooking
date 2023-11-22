namespace Training.IntegrationTest.Core.FlightAggregate.Interfaces;

public interface ICreateFlightService
{
    public Task<Flight> CreateFlight(Flight flight, CancellationToken token);
}