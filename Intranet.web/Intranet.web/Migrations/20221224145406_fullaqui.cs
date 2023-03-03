using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class fullaqui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargosAsgs_PositionEmployees_PositionEmployeeId",
                table: "CargosAsgs");

            migrationBuilder.DropTable(
                name: "PositionEmployees");

            migrationBuilder.DropIndex(
                name: "IX_CargosAsgs_PositionEmployeeId",
                table: "CargosAsgs");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "CargosAsgs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmployedImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: true),
                    ImageId = table.Column<Guid>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployedImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployedImages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionEmp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Position = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionEmp", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteHeadquarters_Nombre",
                table: "SiteHeadquarters",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaVentas_Name",
                table: "SalaVentas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_Name",
                table: "Fabrics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Document",
                table: "Employees",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployedImages_EmployeeId",
                table: "EmployedImages",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployedImages");

            migrationBuilder.DropTable(
                name: "PositionEmp");

            migrationBuilder.DropIndex(
                name: "IX_SiteHeadquarters_Nombre",
                table: "SiteHeadquarters");

            migrationBuilder.DropIndex(
                name: "IX_SalaVentas_Name",
                table: "SalaVentas");

            migrationBuilder.DropIndex(
                name: "IX_Models_Name",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Fabrics_Name",
                table: "Fabrics");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Document",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "CargosAsgs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PositionEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: true),
                    Position = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargosAsgs_PositionEmployeeId",
                table: "CargosAsgs",
                column: "PositionEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionEmployees_EmployeeId",
                table: "PositionEmployees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargosAsgs_PositionEmployees_PositionEmployeeId",
                table: "CargosAsgs",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
