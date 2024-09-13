using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.IntegrationTest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnSeatsToBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Bookings");
        }
    }
}
