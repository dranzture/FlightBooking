using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class CreateFlightService(IRepository<Flight> repository, IEnumerable<ICreateFlightValidationRule> rules, IMapper mapper) : ICreateFlightService
{
    public async Task<Result<Guid>> CreateFlight(CreateFlightRequest request, CancellationToken cancellationToken)
    {
        var flight = mapper.Map<Flight>(request.Flight);
        var validationFailures = new List<ValidationFailure>();

        foreach (var rule in rules)
        {
            var validationFailure = await rule.ValidateAsync(flight, cancellationToken);
            if (validationFailure is not null)
            {
                validationFailures.Add(validationFailure);
            }
        }

        if (validationFailures.Count > 0)
        {
            return Result<Guid>.Failure(validationFailures);
        }
        
        await repository.AddAsync(flight, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        
        
        return Result<Guid>.Success(flight.Id);
    }
}