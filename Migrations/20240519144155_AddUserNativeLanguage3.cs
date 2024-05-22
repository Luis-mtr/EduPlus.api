using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNativeLanguage3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a000c75-02f9-44c8-af9a-2eaf09d94c8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b286af76-2490-4054-bcd1-931978bf7854");

            migrationBuilder.DropColumn(
                name: "NativeLanguageId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d683a03d-be8d-4b4e-976f-cc7e4654f601", null, "User", "USER" },
                    { "edbb34b3-c49e-46a9-81e7-1b93a1c32132", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d683a03d-be8d-4b4e-976f-cc7e4654f601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbb34b3-c49e-46a9-81e7-1b93a1c32132");

            migrationBuilder.AddColumn<int>(
                name: "NativeLanguageId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a000c75-02f9-44c8-af9a-2eaf09d94c8b", null, "User", "USER" },
                    { "b286af76-2490-4054-bcd1-931978bf7854", null, "Admin", "ADMIN" }
                });
        }
    }
}
