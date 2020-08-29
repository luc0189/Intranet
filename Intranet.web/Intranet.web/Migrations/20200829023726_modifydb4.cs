using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class modifydb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateRetiro",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetiro",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
