using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddPointsToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.AddColumn<long>(
                    name: "SessionPoints",
                    table: "AspNetUsers",
                    type: "bigint",
                    nullable: false,
                    defaultValue: 0L);

                migrationBuilder.AddColumn<long>(
                    name: "TotalPoints",
                    table: "AspNetUsers",
                    type: "bigint",
                    nullable: false,
                    defaultValue: 0L);
            }

        protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropColumn(
                    name: "SessionPoints",
                    table: "AspNetUsers");

                migrationBuilder.DropColumn(
                    name: "TotalPoints",
                    table: "AspNetUsers");
            }
    }
}
