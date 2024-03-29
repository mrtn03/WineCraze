using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class DataMigIniFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 3, 29, 11, 31, 25, 462, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 3, 29, 11, 31, 25, 462, DateTimeKind.Local).AddTicks(2744));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 3, 29, 11, 24, 1, 806, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 3, 29, 11, 24, 1, 806, DateTimeKind.Local).AddTicks(8595));
        }
    }
}
