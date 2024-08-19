using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneCapacityService(IRepository<Airplane> airplaneRepository) : IUpdateAirplaneCapacityService
{
    public async Task UpdateCapacityAsync(Guid id, int capacity, CancellationToken token)
    {
        var airplane = await airplaneRepository.GetByIdAsync(id, token);
        if (airplane is null) throw new ArgumentException("Airplane not found");
        airplane.UpdateCapacity(capacity);
        await airplaneRepository.UpdateAsync(airplane, token);
    }
}