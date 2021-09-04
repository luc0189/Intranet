using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class redimidos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SalaVentas",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Redimidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tercero = table.Column<string>(nullable: true),
                    UserRegistra = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<string>(nullable: true),
                    BonoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redimidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redimidos_Bonos_BonoId",
                        column: x => x.BonoId,
                        principalTable: "Bonos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Redimidos_BonoId",
                table: "Redimidos",
                column: "BonoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Redimidos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SalaVentas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }
    }
}
