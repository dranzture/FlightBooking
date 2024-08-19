using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class CreateAirplaneService(IRepository<Airplane> airplaneRepository) : ICreateAirplaneService
{
    public async Task<Guid> CreateAirplaneAsync(Airplane airplane, CancellationToken cancellationToken)
    {
        await airplaneRepository.AddAsync(airplane, cancellationToken);
        return airplane.Id;
    }
}