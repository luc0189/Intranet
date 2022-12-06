using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class positionemployed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "positionEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_positionEmployeeId",
                table: "Employees",
                column: "positionEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PositionEmployees_positionEmployeeId",
                table: "Employees",
                column: "positionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PositionEmployees_positionEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_positionEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "positionEmployeeId",
                table: "Employees");
        }
    }
}
