using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineCraze.Infrastructure.Migrations
{
    public partial class TablesCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Region where is created",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Region where is created");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Wines",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                comment: "This is for the name of wine",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "This is for the name of wine");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Description Of Wine and origin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Description Of Wine and origin");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Wines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Contry of origin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Contry of origin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Region where is created",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Region where is created");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                comment: "This is for the name of wine",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldComment: "This is for the name of wine");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Description Of Wine and origin",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Description Of Wine and origin");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Contry of origin",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Contry of origin");
        }
    }
}
