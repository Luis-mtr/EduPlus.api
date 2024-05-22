using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddedNativeLangToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20c13846-55b6-4e85-bbf4-d5198205bc78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb71869-f3b6-4ed7-a294-5c4bd6e12f61");

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
                    { "40494b93-9c99-4dc6-9427-f0f3a1b83936", null, "User", "USER" },
                    { "479c7e66-f982-443c-9750-0330a548ef62", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NativeLanguageId",
                table: "AspNetUsers",
                column: "NativeLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Languages_NativeLanguageId",
                table: "AspNetUsers",
                column: "NativeLanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Languages_NativeLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NativeLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40494b93-9c99-4dc6-9427-f0f3a1b83936");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "479c7e66-f982-443c-9750-0330a548ef62");

            migrationBuilder.DropColumn(
                name: "NativeLanguageId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20c13846-55b6-4e85-bbf4-d5198205bc78", null, "User", "USER" },
                    { "4eb71869-f3b6-4ed7-a294-5c4bd6e12f61", null, "Admin", "ADMIN" }
                });
        }
    }
}
