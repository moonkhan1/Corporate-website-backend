using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreWebApp1.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 5, 17, 25, 8, 505, DateTimeKind.Local).AddTicks(9056));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 5, 17, 24, 15, 858, DateTimeKind.Local).AddTicks(1063));
        }
    }
}
