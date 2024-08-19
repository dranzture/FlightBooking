using AutoMapper;
using FluentAssertions;
using Newtonsoft.Json;
using Training.FlightBooking.API.Helpers;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.PassengerAggregate;
using Training.FlightBooking.Core.ValueObjects;
using Xunit.Abstractions;

namespace AutoMapperTests;

public class AutoMapperTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mapper _mapper;

    public AutoMapperTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<MapperProfiles>(); });
        configuration.AssertConfigurationIsValid();
        _mapper = new Mapper(configuration);
    }

    [Fact]
    public void AutoMapper_AirplaneEntity_To_AirplaneDto()
    {
        var airplane = new Airplane("Test Model", "Test Manufacturer", 10, 2020);
        var test = _mapper.Map<AirplaneDto>(airplane);

        _testOutputHelper.WriteLine("{0}", JsonConvert.SerializeObject(test));

        test.Should().NotBeNull().And.Match((AirplaneDto f) =>
            f.Id == airplane.Id && f.Model == airplane.Model && f.Manufacturer == airplane.Manufacturer &&
            f.Year == airplane.Year);
    }

    [Fact]
    public void AutoMapper_FlightEntity_To_FlightDto()
    {
        var flight = new Flight(Guid.NewGuid(), 10, DateTime.Now.AddDays(1), DateTime.Now,
            new Location("TX", "San Antonio"), new Location("TX", "Houston"));
        var test = _mapper.Map<FlightDto>(flight);

        _testOutputHelper.WriteLine("{0}", JsonConvert.SerializeObject(test));

        test.Should().NotBeNull().And.Match((FlightDto f) =>
            f.Id == flight.Id && 
            f.Arrival == flight.Arrival && 
            f.Departure == flight.Departure &&
            f.From.City == flight.From.City && 
            f.From.State == flight.From.State && 
            f.To.City == flight.To.City &&
            f.To.State == flight.To.State);
    }

    [Fact]
    public void AutoMapper_BookingEntity_To_BookingDto()
    {
        var booking = new Booking(Guid.NewGuid(), 2);
        booking.AddPassenger(Guid.NewGuid());
        var test = _mapper.Map<BookingDto>(booking);

        _testOutputHelper.WriteLine("{0}", JsonConvert.SerializeObject(test));

        test.Should().NotBeNull().And.Match((BookingDto f) => f.Id == booking.Id);
    }

    [Fact]
    public void AutoMapper_PassengerEntity_To_PassengerDto()
    {
        var passenger = new Passenger("Polat", "Coban", "polatcoban@gmail.com", new DateOnly(1990, 8, 28));

        var test = _mapper.Map<PassengerDto>(passenger);

        _testOutputHelper.WriteLine("{0}", JsonConvert.SerializeObject(test));

        test.Should().NotBeNull().And.Match((PassengerDto f) => f.Id == test.Id);
    }

    [Fact]
    public void AutoMapper_LocationValueObject_To_LocationDto()
    {
        var passenger = new Location("TX", "Houston");

        var test = _mapper.Map<LocationDto>(passenger);

        _testOutputHelper.WriteLine("{0}", JsonConvert.SerializeObject(test));

        test.Should().NotBeNull().And.Match((LocationDto f) => f.State == test.State && f.City == test.City);
    }

    [Fact]
    public void AutoMapper_ItineraryValueObject_To_ItineraryDto()
    {
        var itinerary = new Itinerary("Polat", "Coban", "polatcoban@gmail.com", "210 123 4567");

        var test = _mapper.Map<ItineraryDto>(itinerary);

        _testOutputHelper.WriteLine("{0}", JsonConvert.SerializeObject(test));

        test.Should().NotBeNull().And.Match((ItineraryDto f) =>
            f.Email == test.Email && 
            f.FirstName == test.FirstName && 
            f.LastName == test.LastName &&
            f.PhoneNumber == test.PhoneNumber);
    }
}