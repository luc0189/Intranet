using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class employeId : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.NoAction);
            
        }
    }
}
