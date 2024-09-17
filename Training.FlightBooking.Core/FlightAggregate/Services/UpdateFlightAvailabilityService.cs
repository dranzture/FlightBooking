using FluentValidation.Results;
using Serilog;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Repository;
using Training.FlightBooking.Core.FlightAggregate.Interfaces.Services;
using Training.FlightBooking.Core.Shared;

namespace Training.FlightBooking.Core.FlightAggregate.Services;

public class UpdateFlightAvailabilityService(IFlightRepository repository, ILogger logger)
    : IUpdateFlightAvailabilityService
{
    public async Task DecreaseFlightAvailability(Guid flightId, int seats, CancellationToken token)
    {
        try
        {
            var flight = await repository.GetByIdAsync(flightId, token);
            if (flight is null) throw new ArgumentException("Flight not found");

            flight.DecreaseSeatAvailability(seats);

            await repository.UpdateAsync(flight, token);
        }

        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. FlightId: {FlightId}, Seats: {Seats}",
                nameof(DecreaseFlightAvailability), flightId, seats);
            
        }
    }

    public async Task IncreaseFlightAvailability(Guid flightId, int seats, CancellationToken token)
    {
        try
        {
            var flight = await repository.GetByIdAsync(flightId, token);
            if (flight is null) throw new ArgumentException("Flight not found");

            flight.IncreaseSeatAvailability(seats);

            await repository.UpdateAsync(flight, token);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "---> Error in {Type}. FlightId: {FlightId}, Seats: {Seats}",
                nameof(IncreaseFlightAvailability), flightId, seats);
        }
    }
}