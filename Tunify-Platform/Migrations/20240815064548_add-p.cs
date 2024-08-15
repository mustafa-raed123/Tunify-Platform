using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_Songs_SongId",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistId",
                table: "playlistSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.RenameTable(
                name: "playlistSongs",
                newName: "PlaylistsSongs");

            migrationBuilder.RenameIndex(
                name: "IX_playlistSongs_SongId",
                table: "PlaylistsSongs",
                newName: "IX_PlaylistsSongs_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_playlistSongs_PlaylistId",
                table: "PlaylistsSongs",
                newName: "IX_PlaylistsSongs_PlaylistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs",
                column: "PlaylistSongId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 15, 9, 45, 47, 915, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsSongs_Songs_SongId",
                table: "PlaylistsSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistsSongs_playlists_PlaylistId",
                table: "PlaylistsSongs",
                column: "PlaylistId",
                principalTable: "playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsSongs_Songs_SongId",
                table: "PlaylistsSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistsSongs_playlists_PlaylistId",
                table: "PlaylistsSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs");

            migrationBuilder.RenameTable(
                name: "PlaylistsSongs",
                newName: "playlistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistsSongs_SongId",
                table: "playlistSongs",
                newName: "IX_playlistSongs_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistsSongs_PlaylistId",
                table: "playlistSongs",
                newName: "IX_playlistSongs_PlaylistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                column: "PlaylistSongId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 14, 21, 4, 4, 75, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_Songs_SongId",
                table: "playlistSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistId",
                table: "playlistSongs",
                column: "PlaylistId",
                principalTable: "playlists",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
