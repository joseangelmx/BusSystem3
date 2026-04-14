using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusSystem.DataAccess.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class fixdecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "SeatType",
                table: "Tickets",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "Travels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDateTime",
                table: "Travels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Travels",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FareType",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PricingSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerKm = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricingSettings");

            migrationBuilder.DropColumn(
                name: "ArrivalDateTime",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "DepartureDateTime",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "FareType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tickets",
                newName: "SeatType");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "Travels",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Travels",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
