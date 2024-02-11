using Ardalis.Specification;
using Training.FlightBooking.Core.BookingAggregate;

namespace Training.FlightBooking.Core.BookingAggregate.Specifications;

public sealed class GetOpenBookingByFlightId : SingleResultSpecification<Booking>
{
    public GetOpenBookingByFlightId(Guid id)
    {
        Query.Where(e=>e.Flight.Id == id && e.Status == BookingStatus.Open);
    }
}