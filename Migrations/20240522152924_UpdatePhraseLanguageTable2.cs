using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhraseLanguageTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "WordsLanguages");

            migrationBuilder.RenameTable(
                name: "PhraseLanguages",
                newName: "PhrasesLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_WordLanguages_WordId",
                table: "WordsLanguages",
                newName: "IX_WordsLanguages_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_PhraseLanguages_PhraseId",
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
                    { "da5c0e72-57c5-4848-b042-32fa88eb3475", null, "Admin", "ADMIN" },
                    { "fd5f8c4a-4342-4c38-af79-cfde262ccaba", null, "User", "USER" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "da5c0e72-57c5-4848-b042-32fa88eb3475");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd5f8c4a-4342-4c38-af79-cfde262ccaba");

            migrationBuilder.RenameTable(
                name: "WordsLanguages",
                newName: "WordLanguages");

            migrationBuilder.RenameTable(
                name: "PhrasesLanguages",
                newName: "PhraseLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_WordsLanguages_WordId",
                table: "WordLanguages",
                newName: "IX_WordLanguages_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_PhrasesLanguages_PhraseId",
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
    }
}
