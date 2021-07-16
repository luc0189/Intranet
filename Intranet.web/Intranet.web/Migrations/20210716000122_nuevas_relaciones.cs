using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class nuevas_relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PositionEmployees_PositionEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employees",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "CargosAsgs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAsg = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    PositionEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosAsgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargosAsgs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CargosAsgs_PositionEmployees_PositionEmployeeId",
                        column: x => x.PositionEmployeeId,
                        principalTable: "PositionEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargosAsgs_EmployeeId",
                table: "CargosAsgs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CargosAsgs_PositionEmployeeId",
                table: "CargosAsgs",
                column: "PositionEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargosAsgs");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionEmployeeId",
                table: "Employees",
                column: "PositionEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PositionEmployees_PositionEmployeeId",
                table: "Employees",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
