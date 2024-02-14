using Ardalis.SharedKernel;
using MediatR;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Events;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.Core.Services;

public class BookPassengerService(IRepository<Flight> flightRepository, IRepository<Booking> bookingRepository, IMediator mediator) : IBookPassengerService
{
    public async Task<Guid> BookPassenger(Guid flightId, Passenger passenger, int seats, CancellationToken token)
    {
        var flight = await flightRepository.FirstOrDefaultAsync(new GetFlightById(flightId), token);
        if (flight is null) throw new ArgumentException("Flight not found");
        
        var booking = new Booking(flight, passenger, seats); 
        await bookingRepository.AddAsync(booking, token);
        await bookingRepository.SaveChangesAsync(token);

        await mediator.Publish(new PassengerBookedFlight(booking.Id, booking.Passenger, seats), token);
        
        return booking.Id;
    }
}