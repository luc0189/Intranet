using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class camposadicionales_employes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CtaNomina",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCtaAhorros",
                table: "Employees",
                maxLength: 80,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sueldo",
                table: "Employees",
                maxLength: 80,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CtaNomina",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NumeroCtaAhorros",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Employees");
        }
    }
}
