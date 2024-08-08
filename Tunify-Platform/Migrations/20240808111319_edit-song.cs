using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class editsong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_albums_AlbumId",
                table: "Songs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 8, 14, 13, 19, 105, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_albums_AlbumId",
                table: "Songs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 17, 22, 30, 714, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
