using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class NewSeedDataIni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateCreated",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Date of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of creation");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Apt. 490 23467 Vincenzo Lodge");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "32078 Waelchi Trafficway");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "3 hoog Libberslaan 341b");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: "71 Glen Creek Streeylmar");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address",
                value: "837 Durham St.San Francisco");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: "2023");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: "2022");

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Quantity", "ReportId", "SaleDate", "TotalPrice" },
                values: new object[] { 5, 1, new DateTime(2024, 3, 22, 10, 45, 9, 218, DateTimeKind.Local).AddTicks(9474), 44.00m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "ReportId", "SaleDate", "TotalPrice" },
                values: new object[] { 10, 2, new DateTime(2024, 3, 15, 10, 45, 9, 218, DateTimeKind.Local).AddTicks(9531), 54.00m });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bulstat", "ContactPerson", "Email", "Phone" },
                values: new object[] { 130275868, "supplierA@example.com", "", "" });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bulstat", "ContactPerson", "Email", "Phone" },
                values: new object[] { 205774397, "supplierB@example.com", "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                comment: "Date of creation",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Date of creation");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address",
                value: "");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Quantity", "ReportId", "SaleDate", "TotalPrice" },
                values: new object[] { 2, 0, new DateTime(2024, 3, 29, 10, 31, 40, 937, DateTimeKind.Local).AddTicks(2068), 40.00m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "ReportId", "SaleDate", "TotalPrice" },
                values: new object[] { 1, 0, new DateTime(2024, 3, 29, 10, 31, 40, 937, DateTimeKind.Local).AddTicks(2127), 18.50m });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bulstat", "ContactPerson", "Email", "Phone" },
                values: new object[] { 0, "", "supplierA@example.com", "123-456-7890" });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bulstat", "ContactPerson", "Email", "Phone" },
                values: new object[] { 0, "", "supplierB@example.com", "987-654-3210" });
        }
    }
}
