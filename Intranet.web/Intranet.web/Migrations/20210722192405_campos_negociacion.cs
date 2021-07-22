using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class campos_negociacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Userregistro",
                table: "Pagos",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddColumn<string>(
                name: "DatePaga",
                table: "Negociation",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateVerifica",
                table: "Negociation",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePaga",
                table: "Negociation");

            migrationBuilder.DropColumn(
                name: "DateVerifica",
                table: "Negociation");

            migrationBuilder.AlterColumn<string>(
                name: "Userregistro",
                table: "Pagos",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
