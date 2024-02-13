using FastEndpoints;
using Training.FlightBooking.Core.DTOs;
using Training.FlightBooking.Core.FlightAggregate.Interfaces;
using Training.FlightBooking.Core.FlightAggregate.Requests;
using IMapper = AutoMapper.IMapper;

namespace Training.FlightBooking.API.Endpoints.Flight;

public class Create(ICreateFlightService createFlightService, IMapper mapper) : Endpoint<CreateFlightRequest>
{
    private const string Route = "api/flight/create";

    public override void Configure()
    {
        Post(Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Description = "Create a new flight";
            s.ExampleRequest = new CreateFlightRequest(
                new FlightDto(
                    new LocationDto("LAX", "Los Angeles"),
                    new LocationDto("JFK", "New York"),
                    DateTime.Now.AddDays(2).AddHours(12),
                    DateTime.Now.AddDays(2),
                    120,
                    new AirplaneDto(new Guid(), "Boeing 747", "Boeing", 120, 2020)));
        });

    }

    public override async Task HandleAsync(CreateFlightRequest req, CancellationToken ct)
    {
        var flight = mapper.Map<Core.FlightAggregate.Flight>(req.Flight);
        
        await createFlightService.CreateFlight(flight, ct);
        await SendOkAsync(ct);
    }
}