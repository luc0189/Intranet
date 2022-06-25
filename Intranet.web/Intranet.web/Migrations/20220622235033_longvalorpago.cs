using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class longvalorpago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ValorPagado",
                table: "Pagos",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValorPagado",
                table: "Pagos",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
