using Ardalis.SharedKernel;
using AutoMapper;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;

namespace Training.FlightBooking.Core.Services;

public class CreateFlightService(IRepository<Flight> repository) : ICreateFlightService
{
    public async Task<Flight> CreateFlight(Flight flight, CancellationToken token)
    {
        var flightsByAirplane = new GetFlightsByAirplaneId(flight.Airplane.Id);
        var existingFlight = await repository.ListAsync(flightsByAirplane, token);
        
        if(existingFlight.Any(e=>e.From == flight.From && e.Departure.Date == flight.Departure.Date))
            throw new ArgumentException("Flight already exists");
        
        await repository.AddAsync(flight, token);
        await repository.SaveChangesAsync(token);
        return flight;
    }
}