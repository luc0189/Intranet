using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class clasificationcompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_providercompras",
                table: "providercompras");

            migrationBuilder.RenameTable(
                name: "providercompras",
                newName: "Providercompras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providercompras",
                table: "Providercompras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clasifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Usercrete = table.Column<string>(maxLength: 100, nullable: true),
                    TimeCreate = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clasifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providercompras",
                table: "Providercompras");

            migrationBuilder.RenameTable(
                name: "Providercompras",
                newName: "providercompras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_providercompras",
                table: "providercompras",
                column: "Id");
        }
    }
}
