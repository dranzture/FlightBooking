using Ardalis.Specification;

namespace Training.FlightBooking.Core.BookingAggregate.Specifications;

public sealed class FindByFlightIdAndPassengerId : Specification<Booking>
{
    public FindByFlightIdAndPassengerId(Guid fligtId, Guid passengerId)
    {
        Query
            .Where(b => b.FlightId == fligtId && b.PassengerId == passengerId).AsNoTracking();
    }
}