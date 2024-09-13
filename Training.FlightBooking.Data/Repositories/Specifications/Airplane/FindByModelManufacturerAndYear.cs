using Ardalis.Specification;

namespace Training.FlightBooking.Data.Repositories.Specifications.Airplane;

public sealed class FindByModelManufacturerAndYear : Specification<Core.AirplaneAggregate.Airplane>
{
    public FindByModelManufacturerAndYear(string model, string manufacturer, int year)
    {
        Query
            .Where(a => a.Model == model && a.Manufacturer == manufacturer && a.Year == year).AsNoTracking();
    }
}