using AutoMapper;
using FluentValidation.Results;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class GetFlightByIdService(IFlightRepository repository, IMapper mapper) : IGetFlightById
{
    public async Task<Result<FlightDto?>> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var flight = await repository.GetByIdAsync(id, cancellationToken);
        
        if (flight is null)
        {
            return Result<FlightDto?>.Failure([new ValidationFailure(nameof(Flight), "Flight not found")]);
        }
        
        var flightDto = mapper.Map<FlightDto>(flight);
        return Result<FlightDto?>.Success(flightDto);
    }
}