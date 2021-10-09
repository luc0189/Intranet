using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class tercerosBnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TercBnets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Documento = table.Column<string>(maxLength: 150, nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Nombre2 = table.Column<string>(maxLength: 150, nullable: true),
                    Apellido1 = table.Column<string>(maxLength: 150, nullable: false),
                    Apellido2 = table.Column<string>(maxLength: 150, nullable: true),
                    Telefono = table.Column<string>(maxLength: 150, nullable: false),
                    Correo = table.Column<string>(maxLength: 150, nullable: false),
                    Usercreo = table.Column<string>(maxLength: 150, nullable: false),
                    Datecrea = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TercBnets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TercBnets");
        }
    }
}
