using Microsoft.EntityFrameworkCore;
using Training.FlightBooking.Core.AirplaneAggregate;
using Training.IntegrationTest.Infrastructure.Data;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    public static void AddInitialSetups(this IApplicationBuilder app)
    {
        var appDbContext = app.GetAppDbContext();
        appDbContext.Database.Migrate();
    }
}