﻿using Training.FlightBooking.Data.Data;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    private static AppDbContext GetAppDbContext(this IApplicationBuilder app)
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