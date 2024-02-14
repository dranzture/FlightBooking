﻿using Microsoft.Extensions.DependencyInjection;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.Services;
using Training.FlightBooking.Core.ValueObjects;

namespace CreateBookingServiceTests;

public class CreateFlightServiceTests(FunctionalTestFactory factory) : BaseServiceTest(factory)
{
    [Fact]
    public async Task Creates_Flight_When_There_Is_No_Other_Flight()
    {

    }
    
}