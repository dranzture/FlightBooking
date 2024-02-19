using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

namespace Training.FlightBooking.Core.Services;

public class CreateAirplaneService(IRepository<Airplane> airplaneRepository) : ICreateAirplaneService
{
    public async Task<Guid> CreateAirplane(Airplane airplane, CancellationToken cancellationToken)
    {
        await airplaneRepository.AddAsync(airplane, cancellationToken);
        return airplane.Id;
    }
}