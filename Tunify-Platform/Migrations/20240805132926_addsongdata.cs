using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addsongdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "ArtistId", "Genre", "duration", "title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Rock", new TimeSpan(0, 0, 33, 55, 0), "Billie Jean" },
                    { 2, 2, 2, "Rock", new TimeSpan(0, 0, 55, 55, 0), "Bohemian Rhapsody" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 16, 29, 26, 770, DateTimeKind.Local).AddTicks(8404));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 16, 19, 18, 31, DateTimeKind.Local).AddTicks(5698));
        }
    }
}
