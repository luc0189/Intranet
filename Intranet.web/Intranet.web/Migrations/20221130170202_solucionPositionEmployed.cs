using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class solucionPositionEmployed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Exams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_PositionEmployeeId",
                table: "Exams",
                column: "PositionEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_PositionEmployees_PositionEmployeeId",
                table: "Exams",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_PositionEmployees_PositionEmployeeId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_PositionEmployeeId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Exams");
        }
    }
}
