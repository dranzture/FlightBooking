using Microsoft.EntityFrameworkCore;
using Training.IntegrationTest.Infrastructure.Data;

namespace Training.FlightBooking.API.Helpers;

public static class InitialSetups
{
    public static void AddInitialSetups(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        context?.Database.Migrate();
    }
}