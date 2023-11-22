using Ardalis.Specification;

namespace Training.IntegrationTest.Core.FlightAggregate.Specifications;

public sealed class GetFlightsByAirplaneId : Specification<Flight>
{
    public GetFlightsByAirplaneId(Guid airplaneId)
    {
        Query
            .Where(x => x.Plane.Id == airplaneId && (x.Status != FlightStatus.Canceled ||
                                                     x.Status != FlightStatus.Canceled));
    }
}