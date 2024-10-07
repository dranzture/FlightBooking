using Ardalis.SharedKernel;
using Training.FlightBooking.Core.BookingAggregate;
using Training.FlightBooking.Core.BookingAggregate.Interfaces.Repository;
using Training.FlightBooking.Data.Repositories.Specifications.BookingSpecifications;

namespace Training.FlightBooking.Data.Repositories;

public class BookingRepository(IRepository<Booking> repository) : IBookingRepository
{
    public Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken)
    {
        return repository.AddAsync(booking, cancellationToken);
    }

    public Task UpdateAsync(Booking booking, CancellationToken cancellationToken)
    {
        return repository.UpdateAsync(booking, cancellationToken);
    }

    public Task DeleteAsync(Booking booking, CancellationToken cancellationToken)
    {
        return repository.DeleteAsync(booking, cancellationToken);
    }

    public Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(id, cancellationToken);
    }

    public Task<Booking?> GetByFlightIdAndPassengerId(Booking booking, CancellationToken cancellationToken)
    {
        var passengerNoTrack = new FindByFlightIdAndPassengerId(booking.FlightId, booking.PassengerId);
        return repository.FirstOrDefaultAsync(passengerNoTrack, cancellationToken);
    }


    public Task<List<Booking>> ListAsync(CancellationToken cancellationToken)
    {
        return repository.ListAsync(cancellationToken);
    }
}