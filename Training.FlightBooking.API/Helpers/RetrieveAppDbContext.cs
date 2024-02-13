using Training.IntegrationTest.Infrastructure.Data;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    public static AppDbContext GetAppDbContext(this IApplicationBuilder app)
    {
        var dbContext = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope()
            .ServiceProvider
            .GetService<AppDbContext>();

        if (dbContext is null)
        {
            throw new InvalidOperationException("AppDbContext not found.");
        }
        return dbContext;
    }
}