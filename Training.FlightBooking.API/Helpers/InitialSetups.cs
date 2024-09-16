using Microsoft.EntityFrameworkCore;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    public static void AddInitialSetups(this IApplicationBuilder app)
    {
        var appDbContext = app.GetAppDbContext();
        appDbContext.Database.Migrate();
    }
}