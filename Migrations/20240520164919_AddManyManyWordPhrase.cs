using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddManyManyWordPhrase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d683a03d-be8d-4b4e-976f-cc7e4654f601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbb34b3-c49e-46a9-81e7-1b93a1c32132");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "334e56b7-98b6-40ea-ae73-a9d3377ac52c", null, "Admin", "ADMIN" },
                    { "354ef754-72f8-4e18-b88a-ba4f8aac5e0a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "334e56b7-98b6-40ea-ae73-a9d3377ac52c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "354ef754-72f8-4e18-b88a-ba4f8aac5e0a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d683a03d-be8d-4b4e-976f-cc7e4654f601", null, "User", "USER" },
                    { "edbb34b3-c49e-46a9-81e7-1b93a1c32132", null, "Admin", "ADMIN" }
                });
        }
    }
}
