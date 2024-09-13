using Ardalis.SharedKernel;
using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class GetAirplaneService(IAirplaneRepository repository, IMapper mapper) : IGetAirplaneService
{
    public async Task<Result<AirplaneDto>> GetAirplaneAsync(Guid id, CancellationToken cancellationToken)
    {
        var airplane = await repository.GetByIdAsync(id, cancellationToken);
        return airplane is null
            ? Result<AirplaneDto>.Failure(new List<ValidationFailure>(){new(nameof(Airplane), "Airplane not found")})
            : Result<AirplaneDto>.Success(mapper.Map<AirplaneDto>(airplane));
    }
}