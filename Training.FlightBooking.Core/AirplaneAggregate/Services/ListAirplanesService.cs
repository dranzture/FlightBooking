using Ardalis.SharedKernel;
using AutoMapper;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class ListAirplanesService(IRepository<Airplane> repository, IMapper mapper) : IListAirplanesService
{
    public async Task<Result<IEnumerable<AirplaneDto>>> ListAirplanesAsync(CancellationToken cancellationToken)
    {
        var list = await repository.ListAsync(cancellationToken);
        return Result<IEnumerable<AirplaneDto>>.Success(mapper.Map<IEnumerable<AirplaneDto>>(list));
    }
}