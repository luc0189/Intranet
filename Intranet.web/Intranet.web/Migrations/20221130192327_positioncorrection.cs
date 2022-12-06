using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class positioncorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PositionEmployees_positionEmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_PositionEmployees_PositionEmployeeId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_PositionEmployeeId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "positionEmployeeId",
                table: "Employees",
                newName: "PositionEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_positionEmployeeId",
                table: "Employees",
                newName: "IX_Employees_PositionEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PositionEmployees_PositionEmployeeId",
                table: "Employees",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PositionEmployees_PositionEmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PositionEmployeeId",
                table: "Employees",
                newName: "positionEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionEmployeeId",
                table: "Employees",
                newName: "IX_Employees_positionEmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Exams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_PositionEmployeeId",
                table: "Exams",
                column: "PositionEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PositionEmployees_positionEmployeeId",
                table: "Employees",
                column: "positionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_PositionEmployees_PositionEmployeeId",
                table: "Exams",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
