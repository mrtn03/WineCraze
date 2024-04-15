using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class secondseedconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 4, 15, 17, 27, 27, 659, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 4, 15, 17, 27, 27, 659, DateTimeKind.Local).AddTicks(3911));

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Bulstat", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[] { 3, "Sofia Nadezda ul.Buges", 585555, "suppTest@example.com", "testb@abv.bg", "Test b", "322-677-3110" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaleDate",
                value: new DateTime(2024, 4, 15, 17, 15, 17, 266, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaleDate",
                value: new DateTime(2024, 4, 15, 17, 15, 17, 266, DateTimeKind.Local).AddTicks(7418));
        }
    }
}
