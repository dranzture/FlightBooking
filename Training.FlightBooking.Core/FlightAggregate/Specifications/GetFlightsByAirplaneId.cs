using Ardalis.Specification;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Core.FlightAggregate.Specifications;

public sealed class GetFlightsByAirplaneId : Specification<Flight>
{
    public GetFlightsByAirplaneId(Guid airplaneId)
    {
        Query
            .Where(x => x.AirplaneId == airplaneId && x.Status != FlightStatus.Canceled).AsNoTracking();
    }
}