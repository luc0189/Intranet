using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campañas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameCampaña = table.Column<string>(maxLength: 150, nullable: false),
                    NumberConsecutive = table.Column<string>(maxLength: 60, nullable: false),
                    Datein = table.Column<string>(maxLength: 60, nullable: false),
                    DateOut = table.Column<string>(maxLength: 60, nullable: false),
                    Condiciones = table.Column<string>(maxLength: 500, nullable: false),
                    UsuarioCrea = table.Column<string>(maxLength: 150, nullable: false),
                    DateCrea = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campañas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampañaId = table.Column<int>(nullable: true),
                    TercBnetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletas_Campañas_CampañaId",
                        column: x => x.CampañaId,
                        principalTable: "Campañas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boletas_TercBnets_TercBnetId",
                        column: x => x.TercBnetId,
                        principalTable: "TercBnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletas_CampañaId",
                table: "Boletas",
                column: "CampañaId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletas_TercBnetId",
                table: "Boletas",
                column: "TercBnetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletas");

            migrationBuilder.DropTable(
                name: "Campañas");
        }
    }
}
