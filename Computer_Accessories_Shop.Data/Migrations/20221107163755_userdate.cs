using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Computer_Accessories_Shop.Data.Migrations
{
    public partial class userdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LoginDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginDate",
                table: "AspNetUsers");
        }
    }
}
