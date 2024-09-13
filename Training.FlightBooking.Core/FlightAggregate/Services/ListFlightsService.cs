using AutoMapper;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class ListFlightsService(IFlightRepository repository, IMapper mapper) : IListFlightsService
{
    public async Task<Result<IEnumerable<FlightDto>>> ListFlights(CancellationToken token = default)
    {
        return Result<IEnumerable<FlightDto>>.Success(
            mapper.Map<IEnumerable<FlightDto>>(await repository.ListAsync(token)));
    }
}