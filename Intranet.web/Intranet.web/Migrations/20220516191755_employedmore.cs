using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class employedmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PositionEmployees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionEmployees_EmployeeId",
                table: "PositionEmployees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionEmployees_Employees_EmployeeId",
                table: "PositionEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionEmployees_Employees_EmployeeId",
                table: "PositionEmployees");

            migrationBuilder.DropIndex(
                name: "IX_PositionEmployees_EmployeeId",
                table: "PositionEmployees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PositionEmployees");
        }
    }
}
