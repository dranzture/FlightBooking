using Ardalis.Specification;

namespace Training.FlightBooking.Core.PassengerAggregate.Specifications;

public sealed class GetUserById : SingleResultSpecification<Passenger>
{
    public GetUserById(Guid id)
    {
        Query
            .Where(e => e.Id == id);
    }
}