using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "UserImages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Sons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PersonContacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExamsTypeId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Endowments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpsId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PensionId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cajaCompensacionId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EducationLevels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditEntitiesId",
                table: "Credits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Credits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteHeadquartersId",
                table: "Areas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_EmployeeId",
                table: "UserImages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sons_EmployeeId",
                table: "Sons",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_EmployeeId",
                table: "PersonContacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_EmployeeId",
                table: "Exams",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamsTypeId",
                table: "Exams",
                column: "ExamsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Endowments_EmployeeId",
                table: "Endowments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AreaId",
                table: "Employees",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EpsId",
                table: "Employees",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PensionId",
                table: "Employees",
                column: "PensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionEmployeeId",
                table: "Employees",
                column: "PositionEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_cajaCompensacionId",
                table: "Employees",
                column: "cajaCompensacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevels_EmployeeId",
                table: "EducationLevels",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CreditEntitiesId",
                table: "Credits",
                column: "CreditEntitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_EmployeeId",
                table: "Credits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_SiteHeadquartersId",
                table: "Areas",
                column: "SiteHeadquartersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_SiteHeadquarters_SiteHeadquartersId",
                table: "Areas",
                column: "SiteHeadquartersId",
                principalTable: "SiteHeadquarters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_CreditEntities_CreditEntitiesId",
                table: "Credits",
                column: "CreditEntitiesId",
                principalTable: "CreditEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Employees_EmployeeId",
                table: "Credits",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationLevels_Employees_EmployeeId",
                table: "EducationLevels",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Areas_AreaId",
                table: "Employees",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Eps_EpsId",
                table: "Employees",
                column: "EpsId",
                principalTable: "Eps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Pensions_PensionId",
                table: "Employees",
                column: "PensionId",
                principalTable: "Pensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PositionEmployees_PositionEmployeeId",
                table: "Employees",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CajaCompensacions_cajaCompensacionId",
                table: "Employees",
                column: "cajaCompensacionId",
                principalTable: "CajaCompensacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endowments_Employees_EmployeeId",
                table: "Endowments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Employees_EmployeeId",
                table: "Exams",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_ExamsTypes_ExamsTypeId",
                table: "Exams",
                column: "ExamsTypeId",
                principalTable: "ExamsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_Employees_EmployeeId",
                table: "PersonContacts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sons_Employees_EmployeeId",
                table: "Sons",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_Employees_EmployeeId",
                table: "UserImages",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_SiteHeadquarters_SiteHeadquartersId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_CreditEntities_CreditEntitiesId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Employees_EmployeeId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationLevels_Employees_EmployeeId",
                table: "EducationLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Areas_AreaId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Eps_EpsId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Pensions_PensionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PositionEmployees_PositionEmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CajaCompensacions_cajaCompensacionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Endowments_Employees_EmployeeId",
                table: "Endowments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Employees_EmployeeId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_ExamsTypes_ExamsTypeId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_Employees_EmployeeId",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sons_Employees_EmployeeId",
                table: "Sons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_Employees_EmployeeId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_EmployeeId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_Sons_EmployeeId",
                table: "Sons");

            migrationBuilder.DropIndex(
                name: "IX_PersonContacts_EmployeeId",
                table: "PersonContacts");

            migrationBuilder.DropIndex(
                name: "IX_Exams_EmployeeId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExamsTypeId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Endowments_EmployeeId",
                table: "Endowments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AreaId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EpsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PensionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_cajaCompensacionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EducationLevels_EmployeeId",
                table: "EducationLevels");

            migrationBuilder.DropIndex(
                name: "IX_Credits_CreditEntitiesId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_EmployeeId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Areas_SiteHeadquartersId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamsTypeId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EpsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PensionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "cajaCompensacionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "CreditEntitiesId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "SiteHeadquartersId",
                table: "Areas");
        }
    }
}
