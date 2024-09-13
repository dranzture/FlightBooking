using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.IntegrationTest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameSeatsFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableSeats",
                table: "Flights",
                newName: "Seats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Flights",
                newName: "AvailableSeats");
        }
    }
}
