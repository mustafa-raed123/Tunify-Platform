using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b3ab758-91f8-479a-a88c-95b9c49e8030", "d5e35fbe-3c8a-4b12-bd54-972c15d31742", "User", "USER" },
                    { "501ff55c-d8b2-486e-b634-382cea2db7c5", "27db94f4-ff92-41f4-84bc-471a14553f5f", "Admin", "ADMIN" },
                    { "e0018fba-9e96-4b2c-aa7c-e72da4c57279", "8ebcfa99-f41b-4a67-9300-2ba5c5954144", "Artist", "ARTIST" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 28, 3, 29, 16, 896, DateTimeKind.Local).AddTicks(6923));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b3ab758-91f8-479a-a88c-95b9c49e8030");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "501ff55c-d8b2-486e-b634-382cea2db7c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0018fba-9e96-4b2c-aa7c-e72da4c57279");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 22, 9, 58, 40, 623, DateTimeKind.Local).AddTicks(7592));
        }
    }
}
