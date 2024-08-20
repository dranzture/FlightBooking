using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneCapacityService(
    IRepository<Airplane> airplaneRepository,
    IEnumerable<IUpdateAirplaneValidationRule> rules,
    IMapper mapper) : IUpdateAirplaneCapacityService
{
    public async Task<Result> UpdateCapacityAsync(UpdateAirplaneCapacityRequest req,
        CancellationToken cancellationToken)
    {
        var airplane = await airplaneRepository.GetByIdAsync(req.Id, cancellationToken);
        if (airplane is null)
        {
            var validationFailures = new List<ValidationFailure>
                { new (nameof(Airplane), "Airplane not found") };
            return Result<Guid>.Failure(validationFailures);
        }

        airplane.UpdateCapacity(req.Capacity);

        await airplaneRepository.UpdateAsync(airplane, cancellationToken);

        return Result.Success();
    }
}