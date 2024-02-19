using Ardalis.Specification;
using Training.FlightBooking.Core.FlightAggregate;

namespace Training.FlightBooking.Core.FlightAggregate.Specifications;

public sealed class GetFlightById : SingleResultSpecification<Flight>
{
    public GetFlightById(Guid id)
    {
        Query
            .Where(x => x.Id == id).AsNoTracking();
        
    }
}