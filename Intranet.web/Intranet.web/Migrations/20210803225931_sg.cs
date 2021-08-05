using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class sg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "ProductBonifi");

            migrationBuilder.AlterColumn<string>(
                name: "Articulo",
                table: "ProductBonifi",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "NegociationId",
                table: "ProductBonifi",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCtaAhorros",
                table: "Employees",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBonifi_NegociationId",
                table: "ProductBonifi",
                column: "NegociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBonifi_Negociation_NegociationId",
                table: "ProductBonifi",
                column: "NegociationId",
                principalTable: "Negociation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBonifi_Negociation_NegociationId",
                table: "ProductBonifi");

            migrationBuilder.DropIndex(
                name: "IX_ProductBonifi_NegociationId",
                table: "ProductBonifi");

            migrationBuilder.DropColumn(
                name: "NegociationId",
                table: "ProductBonifi");

            migrationBuilder.AlterColumn<string>(
                name: "Articulo",
                table: "ProductBonifi",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "ProductBonifi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NumeroCtaAhorros",
                table: "Employees",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
