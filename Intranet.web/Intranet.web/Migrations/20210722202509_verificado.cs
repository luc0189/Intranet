using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class verificado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verificados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Novedad = table.Column<string>(maxLength: 500, nullable: false),
                    Dateregistro = table.Column<string>(nullable: true),
                    UserRegistro = table.Column<string>(nullable: true),
                    NegociationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verificados_Negociation_NegociationId",
                        column: x => x.NegociationId,
                        principalTable: "Negociation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verificados_NegociationId",
                table: "Verificados",
                column: "NegociationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verificados");
        }
    }
}
