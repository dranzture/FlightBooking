using Ardalis.Specification;

namespace Training.IntegrationTest.Core.BookingAggregate.Specifications;

public sealed class GetOpenBookingByFlightId : SingleResultSpecification<Booking>
{
    public GetOpenBookingByFlightId(Guid id)
    {
        Query.Where(e=>e.Flight.Id == id && e.Status == BookingStatus.Open);
    }
}