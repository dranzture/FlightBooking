using Ardalis.Specification;

namespace Training.FlightBooking.Core.PassengerAggregate.Specifications;

public sealed class GetPassengerByEmail : SingleResultSpecification<Passenger>
{
    public GetPassengerByEmail(string email)
    {
        Query.Where(e=>e.Email == email);
    }
}