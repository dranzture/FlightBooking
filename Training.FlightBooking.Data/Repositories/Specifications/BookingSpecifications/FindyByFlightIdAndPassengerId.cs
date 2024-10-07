using Ardalis.Specification;

namespace Training.FlightBooking.Data.Repositories.Specifications.BookingSpecifications;

public sealed class FindByFlightIdAndPassengerId : Specification<Core.BookingAggregate.Booking>
{
    public FindByFlightIdAndPassengerId(Guid flightId, Guid passengerId)
    {
        Query
            .Where(b => b.FlightId == flightId && b.PassengerId == passengerId).AsNoTracking();
    }
}