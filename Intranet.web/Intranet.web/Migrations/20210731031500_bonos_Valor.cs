using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class bonos_Valor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "Bonos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Bonos");
        }
    }
}
