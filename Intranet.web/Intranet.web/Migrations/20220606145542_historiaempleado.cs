using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class historiaempleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialEmpleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Notas = table.Column<string>(maxLength: 600, nullable: false),
                    Fecha = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    DateRegistro = table.Column<DateTime>(nullable: false),
                    UserRegistra = table.Column<string>(maxLength: 30, nullable: true),
                    UserModify = table.Column<string>(maxLength: 30, nullable: true),
                    DateModify = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialEmpleados_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEmpleados_EmployeeId",
                table: "HistorialEmpleados",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialEmpleados");
        }
    }
}
