using Training.FlightBooking.Core.AirplaneAggregate;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    public static void InitializeData(this IApplicationBuilder app)
    {
        var dbContext = app.GetAppDbContext();
        
        if (dbContext!.Airplanes.Any()) return;
        var newAirplane = new Airplane("Boeing 747", "Boeing", 120, 2020);
        dbContext.Airplanes.Add(newAirplane);
        dbContext.SaveChanges();
    }
}