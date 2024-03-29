using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class DataIniMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Report Identification");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReportId", "SaleDate" },
                values: new object[] { null, new DateTime(2024, 3, 29, 11, 24, 1, 806, DateTimeKind.Local).AddTicks(8547) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReportId", "SaleDate" },
                values: new object[] { null, new DateTime(2024, 3, 29, 11, 24, 1, 806, DateTimeKind.Local).AddTicks(8595) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Report Identification",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReportId", "SaleDate" },
                values: new object[] { 1, new DateTime(2024, 3, 22, 10, 45, 9, 218, DateTimeKind.Local).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReportId", "SaleDate" },
                values: new object[] { 2, new DateTime(2024, 3, 15, 10, 45, 9, 218, DateTimeKind.Local).AddTicks(9531) });
        }
    }
}
