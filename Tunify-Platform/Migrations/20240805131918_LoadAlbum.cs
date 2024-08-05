using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class LoadAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 16, 19, 18, 31, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "AlbumId", "varchar", "ArtistId", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Thriller", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "The Dark Side of the Moon", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Abbey Road", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "ArtistName",
                value: "Michael Jackson");

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "ArtistId",
                keyValue: 2,
                column: "ArtistName",
                value: "Pink Floyd");

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "ArtistId",
                keyValue: 3,
                column: "ArtistName",
                value: "The Beatles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "albums",
                keyColumn: "AlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "albums",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "albums",
                keyColumn: "AlbumId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 16, 7, 45, 174, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "ArtistId",
                keyValue: 1,
                column: "ArtistName",
                value: "aa");

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "ArtistId",
                keyValue: 2,
                column: "ArtistName",
                value: "aa");

            migrationBuilder.UpdateData(
                table: "artists",
                keyColumn: "ArtistId",
                keyValue: 3,
                column: "ArtistName",
                value: "aa");
        }
    }
}
