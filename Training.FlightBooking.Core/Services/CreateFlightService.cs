using Ardalis.SharedKernel;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;

namespace Training.FlightBooking.Core.Services;

public class CreateFlightService(IRepository<Flight> repository, IEnumerable<ICreateFlightValidationRule> validationRules) : ICreateFlightService
{
    public async Task<Flight> CreateFlight(Flight flight, CancellationToken token)
    {
        foreach (var rule in validationRules)
        {
            await rule.ValidateAsync(flight, token);
        }

        await repository.AddAsync(flight, token);
        await repository.SaveChangesAsync(token);
        
        
        return flight;
    }
}