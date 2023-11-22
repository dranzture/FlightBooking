using Ardalis.Specification;

namespace Training.IntegrationTest.Core.PassengerAggregate.Specifications;

public sealed class GetUserByEmail : SingleResultSpecification<Passenger>
{
    public GetUserByEmail(string email)
    {
        Query.Where(e=>e.Email == email);
    }
}