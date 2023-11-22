using Ardalis.Specification;

namespace Training.IntegrationTest.Core.FlightAggregate.Specifications;

public sealed class GetFlightById : SingleResultSpecification<Flight>
{
    public GetFlightById(Guid id)
    {
        Query
            .Where(x => x.Id == id);
        
    }
}