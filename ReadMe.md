To build migrations:

Change 'InitialCreate' and make sure your root directory is /Training.FlightBooking.API

dotnet ef migrations add InitialCreate -c AppDbContext -p ../Training.FlightBooking.Infrastructure/Training.FlightBooking.Infrastructure.csproj -s Training.FlightBooking.API.csproj -o Data/Migrations
