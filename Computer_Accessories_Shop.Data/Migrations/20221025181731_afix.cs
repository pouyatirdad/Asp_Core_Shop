using Microsoft.EntityFrameworkCore.Migrations;

namespace Computer_Accessories_Shop.Data.Migrations
{
    public partial class afix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Labels");

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "Labels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "Labels");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Labels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
