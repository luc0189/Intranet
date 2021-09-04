using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class salasventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaVentaId",
                table: "Negociation",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRegistra",
                table: "Employees",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "UserModify",
                table: "Employees",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteExpedition",
                table: "Employees",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "SalaVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaVentas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Negociation_SalaVentaId",
                table: "Negociation",
                column: "SalaVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Negociation_SalaVentas_SalaVentaId",
                table: "Negociation",
                column: "SalaVentaId",
                principalTable: "SalaVentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negociation_SalaVentas_SalaVentaId",
                table: "Negociation");

            migrationBuilder.DropTable(
                name: "SalaVentas");

            migrationBuilder.DropIndex(
                name: "IX_Negociation_SalaVentaId",
                table: "Negociation");

            migrationBuilder.DropColumn(
                name: "SalaVentaId",
                table: "Negociation");

            migrationBuilder.AlterColumn<string>(
                name: "UserRegistra",
                table: "Employees",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "UserModify",
                table: "Employees",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteExpedition",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80);
        }
    }
}
