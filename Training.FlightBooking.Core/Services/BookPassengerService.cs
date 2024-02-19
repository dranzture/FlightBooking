using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate;


namespace Training.FlightBooking.Core.Services;

public class BookPassengerService(
    IRepository<Flight> flightRepository,
    IRepository<Booking> bookingRepository,
    IEnumerable<IBookPassengerValidationRule> rules) : IBookPassengerService
{
    public async Task<Guid> BookPassenger(Guid flightId, Guid passengerId, int seats, CancellationToken token)
    {
        var booking = new Booking(flightId, seats);
        booking.AddPassenger(passengerId);
        
        foreach (var rule in rules)
        {
            await rule.ValidateAsync(booking, token);
        }
        
        await bookingRepository.AddAsync(booking, token);
        
        return booking.Id;
    }
}