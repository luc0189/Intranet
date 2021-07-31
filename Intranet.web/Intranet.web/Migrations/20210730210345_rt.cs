using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class rt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roleis");

            migrationBuilder.DropColumn(
                name: "TelProvider",
                table: "Providercompras");

            migrationBuilder.CreateTable(
                name: "Bonos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Redimido = table.Column<bool>(nullable: false),
                    Fechacreado = table.Column<string>(nullable: true),
                    usuariocrea = table.Column<string>(nullable: true),
                    FechaRedimido = table.Column<string>(nullable: true),
                    UsuarioRedime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonos");

            migrationBuilder.AddColumn<int>(
                name: "TelProvider",
                table: "Providercompras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roleis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roleis", x => x.Id);
                });
        }
    }
}
