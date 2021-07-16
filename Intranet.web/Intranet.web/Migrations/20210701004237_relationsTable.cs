using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class relationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Negociation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateIn = table.Column<DateTime>(nullable: false),
                    Detalle = table.Column<string>(maxLength: 300, nullable: false),
                    ValorNegociacion = table.Column<int>(nullable: false),
                    BaseLiquidacion = table.Column<int>(nullable: false),
                    Document = table.Column<string>(maxLength: 300, nullable: false),
                    UsuCreate = table.Column<string>(maxLength: 100, nullable: false),
                    Verificado = table.Column<bool>(nullable: false),
                    Pago = table.Column<bool>(nullable: false),
                    ClasificationId = table.Column<int>(nullable: true),
                    ProvidercomprasId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    MesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negociation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negociation_Clasifications_ClasificationId",
                        column: x => x.ClasificationId,
                        principalTable: "Clasifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negociation_Mes_MesId",
                        column: x => x.MesId,
                        principalTable: "Mes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negociation_Providercompras_ProvidercomprasId",
                        column: x => x.ProvidercomprasId,
                        principalTable: "Providercompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Negociation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Negociation_ClasificationId",
                table: "Negociation",
                column: "ClasificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Negociation_MesId",
                table: "Negociation",
                column: "MesId");

            migrationBuilder.CreateIndex(
                name: "IX_Negociation_ProvidercomprasId",
                table: "Negociation",
                column: "ProvidercomprasId");

            migrationBuilder.CreateIndex(
                name: "IX_Negociation_UserId",
                table: "Negociation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Negociation");

            migrationBuilder.DropTable(
                name: "Mes");
        }
    }
}
