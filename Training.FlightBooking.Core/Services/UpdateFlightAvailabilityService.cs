using Ardalis.SharedKernel;
using Training.IntegrationTest.Core.FlightAggregate;
using Training.IntegrationTest.Core.FlightAggregate.Interfaces;
using Training.IntegrationTest.Core.PassengerAggregate;

namespace Training.IntegrationTest.Core.Services;

public class UpdateFlightAvailabilityService(IRepository<Flight> repository) : IUpdateFlightAvailabilityService
{
    
    public async Task UpdateFlightAvailability(Guid flightId, List<Passenger> passengers, ObserveFlightAvailability observe,
        CancellationToken token)
    {
        var flight = await repository.GetByIdAsync(flightId, token);
        if (flight is null) throw new ArgumentException("Flight not found");

        flight.UpdateSeatAvailability(passengers.Count, observe);
        await repository.SaveChangesAsync(token);
    }
}