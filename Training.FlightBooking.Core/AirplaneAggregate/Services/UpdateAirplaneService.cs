using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.DTOs;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneService(IRepository<Airplane> airplaneRepository) : IUpdateAirplaneService
{
    public Task<AirplaneDto> UpdateAirplane(AirplaneDto airplane, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}