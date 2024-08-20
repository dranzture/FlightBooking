using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneCapacityService(IRepository<Airplane> airplaneRepository, IEnumerable<IUpdateAirplaneValidationRule> rules, IMapper mapper) : IUpdateAirplaneCapacityService
{
    public async Task<Result> UpdateCapacityAsync(UpdateAirplaneCapacityRequest req, CancellationToken cancellationToken)
    {
        var airplaneReq = mapper.Map<Airplane>(req);
        var validationFailures = new List<ValidationFailure>();

        foreach (var rule in rules)
        {
            var validationFailure = await rule.ValidateAsync(airplaneReq, cancellationToken);
            if (validationFailure is not null)
            {
                validationFailures.Add(validationFailure);
            }
        }

        if (validationFailures.Count > 0)
        {
            return Result<Guid>.Failure(validationFailures);
        }

        var airplane = await airplaneRepository.GetByIdAsync(req.Id, cancellationToken);
        
        airplane!.UpdateCapacity(req.Capacity);
        
        await airplaneRepository.UpdateAsync(airplane, cancellationToken);
        
        return Result.Success();
    }
}