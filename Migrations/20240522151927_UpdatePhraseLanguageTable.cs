using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhraseLanguageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhraseLanguage_Languages_LanguageId",
                table: "PhraseLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_PhraseLanguage_Phrases_PhraseId",
                table: "PhraseLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_WordLanguage_Languages_LanguageId",
                table: "WordLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_WordLanguage_Words_WordId",
                table: "WordLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordLanguage",
                table: "WordLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhraseLanguage",
                table: "PhraseLanguage");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38f7a3a6-bcab-4e93-b05f-2bd1328c97df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81e4f53-cf81-48c8-9a1e-04d9bfaea856");

            migrationBuilder.RenameTable(
                name: "WordLanguage",
                newName: "WordLanguages");

            migrationBuilder.RenameTable(
                name: "PhraseLanguage",
                newName: "PhraseLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_WordLanguage_WordId",
                table: "WordLanguages",
                newName: "IX_WordLanguages_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_PhraseLanguage_PhraseId",
                table: "PhraseLanguages",
                newName: "IX_PhraseLanguages_PhraseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordLanguages",
                table: "WordLanguages",
                columns: new[] { "LanguageId", "WordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhraseLanguages",
                table: "PhraseLanguages",
                columns: new[] { "LanguageId", "PhraseId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d8459fc-15fd-42b5-bd65-56161de7039e", null, "User", "USER" },
                    { "6a336f0e-2f45-49af-981e-29c6d2aeb8e4", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PhraseLanguages_Languages_LanguageId",
                table: "PhraseLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhraseLanguages_Phrases_PhraseId",
                table: "PhraseLanguages",
                column: "PhraseId",
                principalTable: "Phrases",
                principalColumn: "PhraseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordLanguages_Languages_LanguageId",
                table: "WordLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordLanguages_Words_WordId",
                table: "WordLanguages",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhraseLanguages_Languages_LanguageId",
                table: "PhraseLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PhraseLanguages_Phrases_PhraseId",
                table: "PhraseLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_WordLanguages_Languages_LanguageId",
                table: "WordLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_WordLanguages_Words_WordId",
                table: "WordLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordLanguages",
                table: "WordLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhraseLanguages",
                table: "PhraseLanguages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d8459fc-15fd-42b5-bd65-56161de7039e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a336f0e-2f45-49af-981e-29c6d2aeb8e4");

            migrationBuilder.RenameTable(
                name: "WordLanguages",
                newName: "WordLanguage");

            migrationBuilder.RenameTable(
                name: "PhraseLanguages",
                newName: "PhraseLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_WordLanguages_WordId",
                table: "WordLanguage",
                newName: "IX_WordLanguage_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_PhraseLanguages_PhraseId",
                table: "PhraseLanguage",
                newName: "IX_PhraseLanguage_PhraseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordLanguage",
                table: "WordLanguage",
                columns: new[] { "LanguageId", "WordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhraseLanguage",
                table: "PhraseLanguage",
                columns: new[] { "LanguageId", "PhraseId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38f7a3a6-bcab-4e93-b05f-2bd1328c97df", null, "User", "USER" },
                    { "f81e4f53-cf81-48c8-9a1e-04d9bfaea856", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PhraseLanguage_Languages_LanguageId",
                table: "PhraseLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhraseLanguage_Phrases_PhraseId",
                table: "PhraseLanguage",
                column: "PhraseId",
                principalTable: "Phrases",
                principalColumn: "PhraseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordLanguage_Languages_LanguageId",
                table: "WordLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordLanguage_Words_WordId",
                table: "WordLanguage",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
