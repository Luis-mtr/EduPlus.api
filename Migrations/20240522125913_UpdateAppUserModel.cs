using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1390046a-be36-4a7b-a4bc-7545dfd8cb9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2471c047-f2c8-44f2-b133-9456b6dd939e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38f7a3a6-bcab-4e93-b05f-2bd1328c97df", null, "User", "USER" },
                    { "f81e4f53-cf81-48c8-9a1e-04d9bfaea856", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38f7a3a6-bcab-4e93-b05f-2bd1328c97df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81e4f53-cf81-48c8-9a1e-04d9bfaea856");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1390046a-be36-4a7b-a4bc-7545dfd8cb9e", null, "Admin", "ADMIN" },
                    { "2471c047-f2c8-44f2-b133-9456b6dd939e", null, "User", "USER" }
                });
        }
    }
}
