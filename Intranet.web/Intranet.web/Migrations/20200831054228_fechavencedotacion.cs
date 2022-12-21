using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class fechavencedotacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Endowments",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateVence",
                table: "Endowments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EndowmentTypeId",
                table: "Endowments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EndowmentsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameType = table.Column<string>(maxLength: 150, nullable: false),
                    EspirationDate = table.Column<int>(nullable: false),
                    UserRegistra = table.Column<string>(nullable: false),
                    UserModify = table.Column<string>(nullable: true),
                    DateRegistro = table.Column<DateTime>(nullable: false),
                    DateModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndowmentsTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endowments_EndowmentTypeId",
                table: "Endowments",
                column: "EndowmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endowments_EndowmentsTypes_EndowmentTypeId",
                table: "Endowments",
                column: "EndowmentTypeId",
                principalTable: "EndowmentsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endowments_EndowmentsTypes_EndowmentTypeId",
                table: "Endowments");

            migrationBuilder.DropTable(
                name: "EndowmentsTypes");

            migrationBuilder.DropIndex(
                name: "IX_Endowments_EndowmentTypeId",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "DateVence",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "EndowmentTypeId",
                table: "Endowments");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Endowments",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
