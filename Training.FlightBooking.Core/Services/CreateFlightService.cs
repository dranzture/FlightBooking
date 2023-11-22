using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.FlightAggregate;
using Training.IntegrationTest.Core.FlightAggregate.Interfaces;
using Training.IntegrationTest.Core.FlightAggregate.Specifications;

namespace Training.IntegrationTest.Core.Services;

public class CreateFlightService(IRepository<Flight> repository) : ICreateFlightService
{
    public async Task<Flight> CreateFlight(Flight flight, CancellationToken token)
    {
        var flightsByAirplane = new GetFlightsByAirplaneId(flight.Plane.Id);
        var existingFlight = await repository.ListAsync(flightsByAirplane, token);
        
        if(existingFlight.Any(e=>e.From == flight.From && e.Departure.Date == flight.Departure.Date))
            throw new ArgumentException("Flight already exists");
        
        await repository.AddAsync(flight, token);
        await repository.SaveChangesAsync(token);
        return flight;
    }
}