using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class DomainTablesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Suppliers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Phone number for contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number for contact");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Suppliers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Name of Supplier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Name of Supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Suppliers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Email for Contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Email for Contact");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Suppliers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Way for contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Way for contact");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Suppliers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Address of supplier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Address of supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Reports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Title of Report",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Title of Report");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reports",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Description of Report",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Description of Report");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Phone number for contact of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number for contact of Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Name of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Name of Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Email of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Email of Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Address of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Address of Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number for contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Phone number for contact");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Name of Supplier",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Name of Supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Email for Contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Email for Contact");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Way for contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Way for contact");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Address of supplier",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Address of supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Title of Report",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Title of Report");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Description of Report",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Description of Report");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number for contact of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Phone number for contact of Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Name of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Name of Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Email of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Email of Customer");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Address of Customer",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Address of Customer");
        }
    }
}
