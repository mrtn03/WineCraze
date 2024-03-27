using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Wines");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedOn",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Year of origin",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Year of origin");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Wines",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Type Of Wine");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "", "john@example.com", "John Doe", "123-456-7890" },
                    { 2, "", "jane@example.com", "Jane Smith", "987-654-3210" },
                    { 3, "", "men@example.com", "Men Gos", "123-634-3110" },
                    { 4, "", "Io@example.com", "Io Geo", "987-123-3210" },
                    { 5, "", "Len@example.com", "Len Dos", "456-789-3210" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "DateCreated", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the sales report for the first quarter of 2023.", "Sales Report Q1 2023" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the inventory report for the year 2022.", "Inventory Report 2022" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Bulstat", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "", 0, "", "supplierA@example.com", "Supplier A", "123-456-7890" },
                    { 2, "", 0, "", "supplierB@example.com", "Supplier B", "987-654-3210" }
                });

            migrationBuilder.InsertData(
                table: "Wines",
                columns: new[] { "Id", "Country", "CreatedOn", "ImageUrl", "Name", "Price", "Quantity", "Region", "SupplierId", "Type" },
                values: new object[,]
                {
                    { 1, "", "2019", "", "Red Wine", 20.00m, 0, "", 0, "Red" },
                    { 2, "", "2020", "", "White Wine", 18.50m, 0, "", 0, "White" },
                    { 3, "", "2018", "", "Rosé Wine", 15.75m, 0, "", 0, "Rosé" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Quantity", "ReportId", "SaleDate", "SupplierId", "TotalPrice", "WineId" },
                values: new object[] { 1, 1, 2, 0, new DateTime(2024, 3, 27, 17, 10, 34, 977, DateTimeKind.Local).AddTicks(2506), 1, 40.00m, 1 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Quantity", "ReportId", "SaleDate", "SupplierId", "TotalPrice", "WineId" },
                values: new object[] { 2, 2, 1, 0, new DateTime(2024, 3, 27, 17, 10, 34, 977, DateTimeKind.Local).AddTicks(2563), 2, 18.50m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Wines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Wines",
                type: "datetime2",
                nullable: false,
                comment: "Year of origin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Year of origin");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Wines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "Description Of Wine and origin");
        }
    }
}
