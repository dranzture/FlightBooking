using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Interfaces;
using Training.FlightBooking.Core.BookingAggregate.Requests;
using Training.FlightBooking.Core.BookingAggregate.Responses;
using Training.FlightBooking.Core.FlightAggregate;
using Training.FlightBooking.Core.FlightAggregate.Specifications;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.Core.Services;

public class CreateBookingService(IRepository<Booking> bookingRepository, IRepository<Flight> flightRepository, IMapper mapper) : ICreateBookingService
{
    public async Task<CreateBookingResponse> CreateBooking(CreateBookingRequest bookingRequest, CancellationToken token)
    {
        var flight = await flightRepository.FirstOrDefaultAsync(new GetFlightById(bookingRequest.Flight.Id), token);
        if (flight is null) throw new ArgumentException("Flight does not exist.");
        
        var newBooking = new Booking(flight);
        
        await bookingRepository.AddAsync(newBooking, token);
        await bookingRepository.SaveChangesAsync(token);
        
        return mapper.Map<CreateBookingResponse>(newBooking);
    }
}