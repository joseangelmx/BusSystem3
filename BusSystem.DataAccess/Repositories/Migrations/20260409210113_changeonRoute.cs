using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusSystem.DataAccess.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class changeonRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Distance",
                table: "Routes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Distance",
                table: "Routes",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
