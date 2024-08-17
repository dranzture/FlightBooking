This is a fun project to implement solutions for flight booking systems.

Includes modernized architectural patterns to increase robostness.


Install Docker Desktop and run the compose file to create the database.

To build migrations:

Change the name of 'InitialCreate' in the script below and make sure your root directory is /Training.FlightBooking.API

dotnet ef migrations add InitialCreate -c AppDbContext -p ../Training.FlightBooking.Infrastructure/Training.FlightBooking.Infrastructure.csproj -s Training.FlightBooking.API.csproj -o Data/Migrations
