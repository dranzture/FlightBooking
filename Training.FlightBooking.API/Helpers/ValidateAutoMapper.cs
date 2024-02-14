using AutoMapper;

namespace Training.FlightBooking.API.Helpers;

public static partial class Helpers
{
    public static void ValidateAutoMapper(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var mapper = services.GetRequiredService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid(); // Validates the AutoMapper configuration
            Console.WriteLine("AutoMapper configuration is valid.");
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<WebApplication>>();
            logger.LogError(ex, "An error occurred while validating AutoMapper configuration");
            // Consider handling the error appropriately (e.g., fail startup or log the error)
            throw; // Rethrow if you want to stop the application from starting
        }
    }
}