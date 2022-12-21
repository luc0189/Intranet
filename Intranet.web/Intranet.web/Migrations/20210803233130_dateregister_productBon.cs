using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class dateregister_productBon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Dateregistro",
                table: "ProductBonifi",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Userregistro",
                table: "ProductBonifi",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dateregistro",
                table: "ProductBonifi");

            migrationBuilder.DropColumn(
                name: "Userregistro",
                table: "ProductBonifi");
        }
    }
}
