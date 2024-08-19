using Ardalis.Specification;

namespace Training.FlightBooking.Core.AirplaneAggregate.Specifications;

public sealed class FindByModelManufacturerAndYear : Specification<Airplane>
{
    public FindByModelManufacturerAndYear(string model, string manufacturer, int year)
    {
        Query
            .Where(a => a.Model == model && a.Manufacturer == manufacturer && a.Year == year).AsNoTracking();
    }
}