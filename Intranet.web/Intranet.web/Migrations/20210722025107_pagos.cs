using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class pagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detalle",
                table: "Negociation",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Novedad = table.Column<string>(maxLength: 500, nullable: false),
                    DocCobro = table.Column<string>(maxLength: 14, nullable: false),
                    DocLegalizacion = table.Column<string>(maxLength: 14, nullable: false),
                    ValorPagado = table.Column<int>(nullable: false),
                    DatePago = table.Column<string>(nullable: true),
                    Dateregistro = table.Column<DateTime>(nullable: false),
                    Userregistro = table.Column<string>(maxLength: 40, nullable: false),
                    NegociationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Negociation_NegociationId",
                        column: x => x.NegociationId,
                        principalTable: "Negociation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_NegociationId",
                table: "Pagos",
                column: "NegociationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.AlterColumn<string>(
                name: "Detalle",
                table: "Negociation",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600);
        }
    }
}
