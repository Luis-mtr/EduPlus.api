using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNativeLanguage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fead82b-6d0e-4351-8b4d-14b3dea1a960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b042caf1-511c-41b2-b644-f9d6cf62091c");

            migrationBuilder.DropColumn(
                name: "NativeLanguage",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a000c75-02f9-44c8-af9a-2eaf09d94c8b", null, "User", "USER" },
                    { "b286af76-2490-4054-bcd1-931978bf7854", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a000c75-02f9-44c8-af9a-2eaf09d94c8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b286af76-2490-4054-bcd1-931978bf7854");

            migrationBuilder.AddColumn<string>(
                name: "NativeLanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7fead82b-6d0e-4351-8b4d-14b3dea1a960", null, "Admin", "ADMIN" },
                    { "b042caf1-511c-41b2-b644-f9d6cf62091c", null, "User", "USER" }
                });
        }
    }
}
