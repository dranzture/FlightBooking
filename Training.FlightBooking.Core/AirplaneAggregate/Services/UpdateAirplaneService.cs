using Ardalis.SharedKernel;
using Training.FlightBooking.Core.AirplaneAggregate.Interfaces;
using Training.FlightBooking.Core.AirplaneAggregate.Requests;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.AirplaneAggregate.Services;

public class UpdateAirplaneService(IRepository<Airplane> repository, IEnumerable<IUpdateAirplaneValidationRule> rules) : IUpdateAirplaneService
{
    public Task<Result> UpdateAirplane(UpdateAirplaneRequest erq, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}