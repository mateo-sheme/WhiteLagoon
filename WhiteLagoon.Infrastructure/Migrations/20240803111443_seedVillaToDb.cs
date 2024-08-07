using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreationDate", "Description", "Name", "Occupancy", "Price", "Sqft", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.", "Royal Villa", 4, 200.0, 559, null },
                    { 2, null, "Description", "Premium Pool Villa", 4, 308.0, 5598, null },
                    { 3, null, "Description", "Luxury Pool Villa", 4, 408.0, 7598, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
