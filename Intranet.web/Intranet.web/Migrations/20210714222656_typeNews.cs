using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class typeNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeNewId",
                table: "Incapacities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incapacities_TypeNewId",
                table: "Incapacities",
                column: "TypeNewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incapacities_TypeNews_TypeNewId",
                table: "Incapacities",
                column: "TypeNewId",
                principalTable: "TypeNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incapacities_TypeNews_TypeNewId",
                table: "Incapacities");

            migrationBuilder.DropTable(
                name: "TypeNews");

            migrationBuilder.DropIndex(
                name: "IX_Incapacities_TypeNewId",
                table: "Incapacities");

            migrationBuilder.DropColumn(
                name: "TypeNewId",
                table: "Incapacities");
        }
    }
}
