using Ardalis.SharedKernel;
using AutoMapper;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;

namespace Training.FlightBooking.Core.Services;

public class CreateFlightService(IRepository<Flight> repository, IEnumerable<IFlightValidationRule> validationRules) : ICreateFlightService
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