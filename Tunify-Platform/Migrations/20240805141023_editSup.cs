using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class editSup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_SubsciptionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SubsciptionId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 17, 10, 23, 351, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubsciptionId",
                table: "Users",
                column: "SubsciptionId",
                unique: true,
                filter: "[SubsciptionId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_SubsciptionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SubsciptionId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Join_Date",
                value: new DateTime(2024, 8, 5, 16, 29, 26, 770, DateTimeKind.Local).AddTicks(8404));

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubsciptionId",
                table: "Users",
                column: "SubsciptionId",
                unique: true);
        }
    }
}
