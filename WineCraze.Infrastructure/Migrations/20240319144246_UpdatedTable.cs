using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class UpdatedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Customers_CustomerId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_CustomerId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Wines");

            migrationBuilder.AddColumn<int>(
                name: "Bulstat",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Bulstat For Supplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bulstat",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Customer Identification");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_CustomerId",
                table: "Wines",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Customers_CustomerId",
                table: "Wines",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
