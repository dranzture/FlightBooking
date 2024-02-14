using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;

namespace Training.FlightBooking.Core.Services;

public class UpdateAirplaneCapacityService(IRepository<Airplane> airplaneRepository) : IUpdateAirplaneCapacityService
{
    public async Task UpdateCapacity(Guid id, int capacity, CancellationToken token)
    {
        var airplane = await airplaneRepository.GetByIdAsync(id, token);
        if (airplane is null) throw new ArgumentException("Airplane not found");
        airplane.UpdateCapacity(capacity);
        await airplaneRepository.SaveChangesAsync(token);
    }
}