using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class editartist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 19, 10, 34, 17, 815, DateTimeKind.Local).AddTicks(530));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 15, 9, 51, 5, 835, DateTimeKind.Local).AddTicks(3109));
        }
    }
}
