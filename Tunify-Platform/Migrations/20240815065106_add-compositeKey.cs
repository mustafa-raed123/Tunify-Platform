using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addcompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistsSongs_PlaylistId",
                table: "PlaylistsSongs");

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongId",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaylistsSongs",
                keyColumn: "PlaylistSongId",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PlaylistSongId",
                table: "PlaylistsSongs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs",
                columns: new[] { "PlaylistId", "SongId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 15, 9, 51, 5, 835, DateTimeKind.Local).AddTicks(3109));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistSongId",
                table: "PlaylistsSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs",
                column: "PlaylistSongId");

            migrationBuilder.InsertData(
                table: "PlaylistsSongs",
                columns: new[] { "PlaylistSongId", "PlaylistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 3 },
                    { 3, 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 15, 9, 45, 47, 915, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistsSongs_PlaylistId",
                table: "PlaylistsSongs",
                column: "PlaylistId");
        }
    }
}
