using Ardalis.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.FlightAggregate;

namespace CreateBookingServiceTests;

public class BaseServiceTest: IClassFixture<FunctionalTestFactory>
{
    private readonly IServiceScope _scope;
    protected readonly IRepository<Flight> _flightRepository;
    protected readonly IRepository<Booking> _bookingRepository;

    protected BaseServiceTest(FunctionalTestFactory factory)
    {
        _scope  = factory.Services.CreateScope();
        _flightRepository = _scope.ServiceProvider.GetRequiredService<IRepository<Flight>>();
        _bookingRepository = _scope.ServiceProvider.GetRequiredService<IRepository<Booking>>();
    }
}