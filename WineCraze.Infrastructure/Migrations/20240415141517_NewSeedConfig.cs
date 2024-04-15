using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class NewSeedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SaleDate", "SupplierId" },
                values: new object[] { new DateTime(2024, 4, 15, 17, 15, 17, 266, DateTimeKind.Local).AddTicks(7364), 0 });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SaleDate", "SupplierId" },
                values: new object[] { new DateTime(2024, 4, 15, 17, 15, 17, 266, DateTimeKind.Local).AddTicks(7418), 0 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email", "Phone" },
                values: new object[] { "Sofia Nadezda ul.Budinci", "toshotosh@abv.bg", "123-634-3110" });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Bulstat", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[] { "Sofia Nadezda ul.Rozehn", 130985868, "supplierA@example.com", "abvabv@abv.bg", "Supplier b", "123-677-3110" });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Quantity", "Region", "SupplierId" },
                values: new object[] { 20, "Vidrare", 0 });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "Region", "SupplierId" },
                values: new object[] { 20, "Targovishte", 0 });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Quantity", "Region", "SupplierId" },
                values: new object[] { 20, "Shumen", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SaleDate", "SupplierId" },
                values: new object[] { new DateTime(2024, 4, 4, 17, 26, 39, 277, DateTimeKind.Local).AddTicks(5447), 1 });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SaleDate", "SupplierId" },
                values: new object[] { new DateTime(2024, 4, 4, 17, 26, 39, 277, DateTimeKind.Local).AddTicks(5502), 2 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email", "Phone" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Bulstat", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[] { "", 205774397, "supplierB@example.com", "", "Supplier B", "" });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Quantity", "Region", "SupplierId" },
                values: new object[] { 0, "", 2 });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Quantity", "Region", "SupplierId" },
                values: new object[] { 0, "", 1 });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Quantity", "Region", "SupplierId" },
                values: new object[] { 0, "", 1 });
        }
    }
}
