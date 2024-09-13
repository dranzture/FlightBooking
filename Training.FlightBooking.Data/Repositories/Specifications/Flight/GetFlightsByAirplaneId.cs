using Ardalis.Specification;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Data.Repositories.Specifications.Flight;

public sealed class GetFlightsByAirplaneId : Specification<Core.FlightAggregate.Flight>
{
    public GetFlightsByAirplaneId(Guid airplaneId)
    {
        Query
            .Where(x => x.AirplaneId == airplaneId && x.Status != FlightStatus.Canceled).AsNoTracking();
    }
}