FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Training.FlightBooking.API/Training.FlightBooking.API.csproj", "Training.FlightBooking.API/"]
RUN dotnet restore "Training.FlightBooking.API/Training.FlightBooking.API.csproj"
COPY . .
WORKDIR "/src/Training.FlightBooking.API"
RUN dotnet build "Training.FlightBooking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Training.FlightBooking.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Training.FlightBooking.API.dll"]
