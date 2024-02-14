using Training.FlightBooking.Core.AirplaneAggregate;
using Training.FlightBooking.Core.PassengerAggregate;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    public static void InitializeData(this IApplicationBuilder app)
    {
        var dbContext = app.GetAppDbContext();
        
        if (dbContext!.Passengers.Any()) return;
        var passenger = new Passenger("Polat", "Coban", "polatcoban@gmail.com", new DateOnly(1990, 8, 28));
        dbContext.Passengers.Add(passenger);
        dbContext.SaveChanges();
        
    }
}