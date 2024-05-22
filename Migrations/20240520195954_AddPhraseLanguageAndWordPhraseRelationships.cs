using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddPhraseLanguageAndWordPhraseRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhrasesLanguages_Languages_LanguageId",
                table: "PhrasesLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_PhrasesLanguages_Phrases_PhraseId",
                table: "PhrasesLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_WordsLanguages_Languages_LanguageId",
                table: "WordsLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_WordsLanguages_Words_WordId",
                table: "WordsLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordsLanguages",
                table: "WordsLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhrasesLanguages",
                table: "PhrasesLanguages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "334e56b7-98b6-40ea-ae73-a9d3377ac52c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "354ef754-72f8-4e18-b88a-ba4f8aac5e0a");

            migrationBuilder.RenameTable(
                name: "WordsLanguages",
                newName: "WordLanguage");

            migrationBuilder.RenameTable(
                name: "PhrasesLanguages",
                newName: "PhraseLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_WordsLanguages_WordId",
                table: "WordLanguage",
                newName: "IX_WordLanguage_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_PhrasesLanguages_PhraseId",
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
                    { "540b658c-d4ff-4f69-bfb0-492c396ec17a", null, "User", "USER" },
                    { "f1d32626-fe46-4568-9e9b-7f5b1b516ac5", null, "Admin", "ADMIN" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "540b658c-d4ff-4f69-bfb0-492c396ec17a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1d32626-fe46-4568-9e9b-7f5b1b516ac5");

            migrationBuilder.RenameTable(
                name: "WordLanguage",
                newName: "WordsLanguages");

            migrationBuilder.RenameTable(
                name: "PhraseLanguage",
                newName: "PhrasesLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_WordLanguage_WordId",
                table: "WordsLanguages",
                newName: "IX_WordsLanguages_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_PhraseLanguage_PhraseId",
                table: "PhrasesLanguages",
                newName: "IX_PhrasesLanguages_PhraseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordsLanguages",
                table: "WordsLanguages",
                columns: new[] { "LanguageId", "WordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhrasesLanguages",
                table: "PhrasesLanguages",
                columns: new[] { "LanguageId", "PhraseId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "334e56b7-98b6-40ea-ae73-a9d3377ac52c", null, "Admin", "ADMIN" },
                    { "354ef754-72f8-4e18-b88a-ba4f8aac5e0a", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PhrasesLanguages_Languages_LanguageId",
                table: "PhrasesLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhrasesLanguages_Phrases_PhraseId",
                table: "PhrasesLanguages",
                column: "PhraseId",
                principalTable: "Phrases",
                principalColumn: "PhraseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordsLanguages_Languages_LanguageId",
                table: "WordsLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordsLanguages_Words_WordId",
                table: "WordsLanguages",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
