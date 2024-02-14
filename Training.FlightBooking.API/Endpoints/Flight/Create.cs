using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using Training.FlightBooking.Core.ValueObjects;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.API.Endpoints.Flight;

public class Create(ICreateFlightService createFlightService, IMapper mapper) : Endpoint<CreateFlightRequest>
{
    private const string Route = "api/Flight/Create";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Create a new flight";
            s.ExampleRequest = new CreateFlightRequest(
                new FlightDto(
                    new Guid(),
                    120,
                    new LocationDto("LAX", "Los Angeles"),
                    new LocationDto("JFK", "New York"),
                    DateTime.Now.AddDays(2).AddHours(12),
                    DateTime.Now.AddDays(2)
                ));
        });
    }

    public override async Task HandleAsync(CreateFlightRequest req, CancellationToken ct)
    {
        var flight = new Core.FlightAggregate.Flight(
            req.Flight.AirplaneId,
            req.Flight.AvailableSeats,
            req.Flight.Departure,
            req.Flight.Arrival,
            mapper.Map<Location>(req.Flight.To),
            mapper.Map<Location>(req.Flight.From)
          );

        await createFlightService.CreateFlight(flight, ct);
        await SendOkAsync(ct);
    }
}