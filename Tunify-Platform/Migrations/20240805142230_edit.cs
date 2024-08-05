using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 1,
                column: "SubsciptionsType",
                value: "Family");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 2,
                column: "SubsciptionsType",
                value: "Free");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 3,
                column: "SubsciptionsType",
                value: "Premium");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 4,
                column: "SubsciptionsType",
                value: "Free");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 17, 22, 30, 714, DateTimeKind.Local).AddTicks(4273));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 1,
                column: "SubsciptionsType",
                value: "Playlist");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 2,
                column: "SubsciptionsType",
                value: "PlayStation");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 3,
                column: "SubsciptionsType",
                value: "Artist");

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubsciptionsId",
                keyValue: 4,
                column: "SubsciptionsType",
                value: "Album");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 17, 10, 23, 351, DateTimeKind.Local).AddTicks(8008));
        }
    }
}
