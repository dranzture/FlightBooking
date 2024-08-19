using Ardalis.Specification;

namespace Training.FlightBooking.Core.BookingAggregate.Specifications;

public sealed class FindByFlightIdAndPassengerId : Specification<Booking>
{
    public FindByFlightIdAndPassengerId(Guid flightId, Guid passengerId)
    {
        Query
            .Where(b => b.FlightId == flightId && b.PassengerId == passengerId).AsNoTracking();
    }
}