using Ardalis.Specification;

namespace Training.FlightBooking.Core.PassengerAggregate.Specifications;

public sealed class GetPassengerById : SingleResultSpecification<Passenger>
{
    public GetPassengerById(Guid id)
    {
        Query
            .Where(e => e.Id == id).AsNoTracking();
    }
}