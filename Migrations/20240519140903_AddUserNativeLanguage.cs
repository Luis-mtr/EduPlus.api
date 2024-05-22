using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNativeLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNativeLanguage_AspNetUsers_AppUserId",
                table: "UserNativeLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNativeLanguage_Languages_LanguageId",
                table: "UserNativeLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNativeLanguage_Languages_LanguageId1",
                table: "UserNativeLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNativeLanguage",
                table: "UserNativeLanguage");

            migrationBuilder.DropIndex(
                name: "IX_UserNativeLanguage_LanguageId1",
                table: "UserNativeLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "460f6d14-50c7-403c-840e-83b2c9072ab7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a6fb5b4-69b8-45e4-bd8f-0fc902b0a64b");

            migrationBuilder.DropColumn(
                name: "LanguageId1",
                table: "UserNativeLanguage");

            migrationBuilder.RenameTable(
                name: "UserNativeLanguage",
                newName: "UserNativeLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_UserNativeLanguage_LanguageId",
                table: "UserNativeLanguages",
                newName: "IX_UserNativeLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserNativeLanguage_AppUserId",
                table: "UserNativeLanguages",
                newName: "IX_UserNativeLanguages_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNativeLanguages",
                table: "UserNativeLanguages",
                columns: new[] { "AppUserId", "LanguageId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7fead82b-6d0e-4351-8b4d-14b3dea1a960", null, "Admin", "ADMIN" },
                    { "b042caf1-511c-41b2-b644-f9d6cf62091c", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserNativeLanguages_AspNetUsers_AppUserId",
                table: "UserNativeLanguages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNativeLanguages_Languages_LanguageId",
                table: "UserNativeLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNativeLanguages_AspNetUsers_AppUserId",
                table: "UserNativeLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNativeLanguages_Languages_LanguageId",
                table: "UserNativeLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNativeLanguages",
                table: "UserNativeLanguages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fead82b-6d0e-4351-8b4d-14b3dea1a960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b042caf1-511c-41b2-b644-f9d6cf62091c");

            migrationBuilder.RenameTable(
                name: "UserNativeLanguages",
                newName: "UserNativeLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_UserNativeLanguages_LanguageId",
                table: "UserNativeLanguage",
                newName: "IX_UserNativeLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_UserNativeLanguages_AppUserId",
                table: "UserNativeLanguage",
                newName: "IX_UserNativeLanguage_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId1",
                table: "UserNativeLanguage",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNativeLanguage",
                table: "UserNativeLanguage",
                columns: new[] { "AppUserId", "LanguageId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "460f6d14-50c7-403c-840e-83b2c9072ab7", null, "Admin", "ADMIN" },
                    { "8a6fb5b4-69b8-45e4-bd8f-0fc902b0a64b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNativeLanguage_LanguageId1",
                table: "UserNativeLanguage",
                column: "LanguageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNativeLanguage_AspNetUsers_AppUserId",
                table: "UserNativeLanguage",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNativeLanguage_Languages_LanguageId",
                table: "UserNativeLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNativeLanguage_Languages_LanguageId1",
                table: "UserNativeLanguage",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "LanguageId");
        }
    }
}
