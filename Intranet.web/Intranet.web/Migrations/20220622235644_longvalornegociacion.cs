using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class longvalornegociacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ValorNegociacion",
                table: "Negociation",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "BaseLiquidacion",
                table: "Negociation",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValorNegociacion",
                table: "Negociation",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "BaseLiquidacion",
                table: "Negociation",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
