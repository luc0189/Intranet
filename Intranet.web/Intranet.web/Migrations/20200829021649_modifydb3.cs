using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class modifydb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Managers_ManagerId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Recursoshumanos_RecursoshumanosId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_StoreLeaders_StoreLeaderId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CajaCompensacions_cajaCompensacionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Endowments_Managers_ManagerId",
                table: "Endowments");

            migrationBuilder.DropForeignKey(
                name: "FK_Endowments_Recursoshumanos_RecursoshumanosId",
                table: "Endowments");

            migrationBuilder.DropForeignKey(
                name: "FK_Endowments_StoreLeaders_StoreLeaderId",
                table: "Endowments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Managers_ManagerId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Recursoshumanos_RecursoshumanosId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_StoreLeaders_StoreLeaderId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Areas_AreaId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Eps_EpsId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Pensions_PensionId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_PositionEmployees_PositionEmployeeId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_CajaCompensacions_cajaCompensacionId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_Managers_ManagerId",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_Recursoshumanos_RecursoshumanosId",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_StoreLeaders_StoreLeaderId",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursoshumanos_Areas_AreaId",
                table: "Recursoshumanos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursoshumanos_Eps_EpsId",
                table: "Recursoshumanos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursoshumanos_Pensions_PensionId",
                table: "Recursoshumanos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursoshumanos_PositionEmployees_PositionEmployeeId",
                table: "Recursoshumanos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursoshumanos_CajaCompensacions_cajaCompensacionId",
                table: "Recursoshumanos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sons_Managers_ManagerId",
                table: "Sons");

            migrationBuilder.DropForeignKey(
                name: "FK_Sons_Recursoshumanos_RecursoshumanosId",
                table: "Sons");

            migrationBuilder.DropForeignKey(
                name: "FK_Sons_StoreLeaders_StoreLeaderId",
                table: "Sons");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLeaders_Areas_AreaId",
                table: "StoreLeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLeaders_Eps_EpsId",
                table: "StoreLeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLeaders_Pensions_PensionId",
                table: "StoreLeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLeaders_PositionEmployees_PositionEmployeeId",
                table: "StoreLeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreLeaders_CajaCompensacions_cajaCompensacionId",
                table: "StoreLeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_Managers_ManagerId",
                table: "UserImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_Recursoshumanos_RecursoshumanosId",
                table: "UserImages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_StoreLeaders_StoreLeaderId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_ManagerId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_RecursoshumanosId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_StoreLeaderId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_StoreLeaders_AreaId",
                table: "StoreLeaders");

            migrationBuilder.DropIndex(
                name: "IX_StoreLeaders_EpsId",
                table: "StoreLeaders");

            migrationBuilder.DropIndex(
                name: "IX_StoreLeaders_PensionId",
                table: "StoreLeaders");

            migrationBuilder.DropIndex(
                name: "IX_StoreLeaders_PositionEmployeeId",
                table: "StoreLeaders");

            migrationBuilder.DropIndex(
                name: "IX_StoreLeaders_cajaCompensacionId",
                table: "StoreLeaders");

            migrationBuilder.DropIndex(
                name: "IX_Sons_ManagerId",
                table: "Sons");

            migrationBuilder.DropIndex(
                name: "IX_Sons_RecursoshumanosId",
                table: "Sons");

            migrationBuilder.DropIndex(
                name: "IX_Sons_StoreLeaderId",
                table: "Sons");

            migrationBuilder.DropIndex(
                name: "IX_Recursoshumanos_AreaId",
                table: "Recursoshumanos");

            migrationBuilder.DropIndex(
                name: "IX_Recursoshumanos_EpsId",
                table: "Recursoshumanos");

            migrationBuilder.DropIndex(
                name: "IX_Recursoshumanos_PensionId",
                table: "Recursoshumanos");

            migrationBuilder.DropIndex(
                name: "IX_Recursoshumanos_PositionEmployeeId",
                table: "Recursoshumanos");

            migrationBuilder.DropIndex(
                name: "IX_Recursoshumanos_cajaCompensacionId",
                table: "Recursoshumanos");

            migrationBuilder.DropIndex(
                name: "IX_PersonContacts_ManagerId",
                table: "PersonContacts");

            migrationBuilder.DropIndex(
                name: "IX_PersonContacts_RecursoshumanosId",
                table: "PersonContacts");

            migrationBuilder.DropIndex(
                name: "IX_PersonContacts_StoreLeaderId",
                table: "PersonContacts");

            migrationBuilder.DropIndex(
                name: "IX_Managers_AreaId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_EpsId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_PensionId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_PositionEmployeeId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_cajaCompensacionId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ManagerId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_RecursoshumanosId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_StoreLeaderId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Endowments_ManagerId",
                table: "Endowments");

            migrationBuilder.DropIndex(
                name: "IX_Endowments_RecursoshumanosId",
                table: "Endowments");

            migrationBuilder.DropIndex(
                name: "IX_Endowments_StoreLeaderId",
                table: "Endowments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Credits_ManagerId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_RecursoshumanosId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_StoreLeaderId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "RecursoshumanosId",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "StoreLeaderId",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "StoreLeaders");

            migrationBuilder.DropColumn(
                name: "EpsId",
                table: "StoreLeaders");

            migrationBuilder.DropColumn(
                name: "PensionId",
                table: "StoreLeaders");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "StoreLeaders");

            migrationBuilder.DropColumn(
                name: "cajaCompensacionId",
                table: "StoreLeaders");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "RecursoshumanosId",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "StoreLeaderId",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Recursoshumanos");

            migrationBuilder.DropColumn(
                name: "EpsId",
                table: "Recursoshumanos");

            migrationBuilder.DropColumn(
                name: "PensionId",
                table: "Recursoshumanos");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Recursoshumanos");

            migrationBuilder.DropColumn(
                name: "cajaCompensacionId",
                table: "Recursoshumanos");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "RecursoshumanosId",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "StoreLeaderId",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EpsId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "PensionId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "cajaCompensacionId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "RecursoshumanosId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "StoreLeaderId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "RecursoshumanosId",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "StoreLeaderId",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "RecursoshumanosId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "StoreLeaderId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "Arl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateRetiro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "License",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NivelEducation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rh",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SiteBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SiteExpedition",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "cajaCompensacionId",
                table: "Employees",
                newName: "CajaCompensacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_cajaCompensacionId",
                table: "Employees",
                newName: "IX_Employees_CajaCompensacionId");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Arl",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateIngreso",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRetiro",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Document",
                table: "Employees",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "License",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Movil",
                table: "Employees",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NivelEducation",
                table: "Employees",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rh",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteBirth",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteExpedition",
                table: "Employees",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Employees",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "Employees",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Document",
                table: "AspNetUsers",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Incapacity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Novedad = table.Column<string>(maxLength: 350, nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incapacity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incapacity_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incapacity_EmployeeId",
                table: "Incapacity",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CajaCompensacions_CajaCompensacionId",
                table: "Employees",
                column: "CajaCompensacionId",
                principalTable: "CajaCompensacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CajaCompensacions_CajaCompensacionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Incapacity");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Arl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateIngreso",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateRetiro",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "License",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Movil",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NivelEducation",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Rh",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SiteBirth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SiteExpedition",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CajaCompensacionId",
                table: "Employees",
                newName: "cajaCompensacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CajaCompensacionId",
                table: "Employees",
                newName: "IX_Employees_cajaCompensacionId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "UserImages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoshumanosId",
                table: "UserImages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreLeaderId",
                table: "UserImages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "StoreLeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpsId",
                table: "StoreLeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PensionId",
                table: "StoreLeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "StoreLeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cajaCompensacionId",
                table: "StoreLeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Sons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoshumanosId",
                table: "Sons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreLeaderId",
                table: "Sons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Recursoshumanos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpsId",
                table: "Recursoshumanos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PensionId",
                table: "Recursoshumanos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Recursoshumanos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cajaCompensacionId",
                table: "Recursoshumanos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "PersonContacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoshumanosId",
                table: "PersonContacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreLeaderId",
                table: "PersonContacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpsId",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PensionId",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cajaCompensacionId",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoshumanosId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreLeaderId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Endowments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoshumanosId",
                table: "Endowments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreLeaderId",
                table: "Endowments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Credits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecursoshumanosId",
                table: "Credits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreLeaderId",
                table: "Credits",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "AspNetUsers",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<bool>(
                name: "Arl",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DateRetiro",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "License",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NivelEducation",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rh",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteBirth",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteExpedition",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_ManagerId",
                table: "UserImages",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_RecursoshumanosId",
                table: "UserImages",
                column: "RecursoshumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_StoreLeaderId",
                table: "UserImages",
                column: "StoreLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLeaders_AreaId",
                table: "StoreLeaders",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLeaders_EpsId",
                table: "StoreLeaders",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLeaders_PensionId",
                table: "StoreLeaders",
                column: "PensionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLeaders_PositionEmployeeId",
                table: "StoreLeaders",
                column: "PositionEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreLeaders_cajaCompensacionId",
                table: "StoreLeaders",
                column: "cajaCompensacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sons_ManagerId",
                table: "Sons",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sons_RecursoshumanosId",
                table: "Sons",
                column: "RecursoshumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_Sons_StoreLeaderId",
                table: "Sons",
                column: "StoreLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Recursoshumanos_AreaId",
                table: "Recursoshumanos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recursoshumanos_EpsId",
                table: "Recursoshumanos",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Recursoshumanos_PensionId",
                table: "Recursoshumanos",
                column: "PensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recursoshumanos_PositionEmployeeId",
                table: "Recursoshumanos",
                column: "PositionEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recursoshumanos_cajaCompensacionId",
                table: "Recursoshumanos",
                column: "cajaCompensacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_ManagerId",
                table: "PersonContacts",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_RecursoshumanosId",
                table: "PersonContacts",
                column: "RecursoshumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_StoreLeaderId",
                table: "PersonContacts",
                column: "StoreLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_AreaId",
                table: "Managers",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_EpsId",
                table: "Managers",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PensionId",
                table: "Managers",
                column: "PensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PositionEmployeeId",
                table: "Managers",
                column: "PositionEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_cajaCompensacionId",
                table: "Managers",
                column: "cajaCompensacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ManagerId",
                table: "Exams",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_RecursoshumanosId",
                table: "Exams",
                column: "RecursoshumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StoreLeaderId",
                table: "Exams",
                column: "StoreLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Endowments_ManagerId",
                table: "Endowments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Endowments_RecursoshumanosId",
                table: "Endowments",
                column: "RecursoshumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_Endowments_StoreLeaderId",
                table: "Endowments",
                column: "StoreLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_ManagerId",
                table: "Credits",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_RecursoshumanosId",
                table: "Credits",
                column: "RecursoshumanosId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_StoreLeaderId",
                table: "Credits",
                column: "StoreLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Managers_ManagerId",
                table: "Credits",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Recursoshumanos_RecursoshumanosId",
                table: "Credits",
                column: "RecursoshumanosId",
                principalTable: "Recursoshumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_StoreLeaders_StoreLeaderId",
                table: "Credits",
                column: "StoreLeaderId",
                principalTable: "StoreLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
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
                name: "FK_Endowments_Managers_ManagerId",
                table: "Endowments",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endowments_Recursoshumanos_RecursoshumanosId",
                table: "Endowments",
                column: "RecursoshumanosId",
                principalTable: "Recursoshumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endowments_StoreLeaders_StoreLeaderId",
                table: "Endowments",
                column: "StoreLeaderId",
                principalTable: "StoreLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Managers_ManagerId",
                table: "Exams",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Recursoshumanos_RecursoshumanosId",
                table: "Exams",
                column: "RecursoshumanosId",
                principalTable: "Recursoshumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_StoreLeaders_StoreLeaderId",
                table: "Exams",
                column: "StoreLeaderId",
                principalTable: "StoreLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Areas_AreaId",
                table: "Managers",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Eps_EpsId",
                table: "Managers",
                column: "EpsId",
                principalTable: "Eps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Pensions_PensionId",
                table: "Managers",
                column: "PensionId",
                principalTable: "Pensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_PositionEmployees_PositionEmployeeId",
                table: "Managers",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_CajaCompensacions_cajaCompensacionId",
                table: "Managers",
                column: "cajaCompensacionId",
                principalTable: "CajaCompensacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_Managers_ManagerId",
                table: "PersonContacts",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_Recursoshumanos_RecursoshumanosId",
                table: "PersonContacts",
                column: "RecursoshumanosId",
                principalTable: "Recursoshumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_StoreLeaders_StoreLeaderId",
                table: "PersonContacts",
                column: "StoreLeaderId",
                principalTable: "StoreLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursoshumanos_Areas_AreaId",
                table: "Recursoshumanos",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursoshumanos_Eps_EpsId",
                table: "Recursoshumanos",
                column: "EpsId",
                principalTable: "Eps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursoshumanos_Pensions_PensionId",
                table: "Recursoshumanos",
                column: "PensionId",
                principalTable: "Pensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursoshumanos_PositionEmployees_PositionEmployeeId",
                table: "Recursoshumanos",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursoshumanos_CajaCompensacions_cajaCompensacionId",
                table: "Recursoshumanos",
                column: "cajaCompensacionId",
                principalTable: "CajaCompensacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sons_Managers_ManagerId",
                table: "Sons",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sons_Recursoshumanos_RecursoshumanosId",
                table: "Sons",
                column: "RecursoshumanosId",
                principalTable: "Recursoshumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sons_StoreLeaders_StoreLeaderId",
                table: "Sons",
                column: "StoreLeaderId",
                principalTable: "StoreLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLeaders_Areas_AreaId",
                table: "StoreLeaders",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLeaders_Eps_EpsId",
                table: "StoreLeaders",
                column: "EpsId",
                principalTable: "Eps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLeaders_Pensions_PensionId",
                table: "StoreLeaders",
                column: "PensionId",
                principalTable: "Pensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLeaders_PositionEmployees_PositionEmployeeId",
                table: "StoreLeaders",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreLeaders_CajaCompensacions_cajaCompensacionId",
                table: "StoreLeaders",
                column: "cajaCompensacionId",
                principalTable: "CajaCompensacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_Managers_ManagerId",
                table: "UserImages",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_Recursoshumanos_RecursoshumanosId",
                table: "UserImages",
                column: "RecursoshumanosId",
                principalTable: "Recursoshumanos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_StoreLeaders_StoreLeaderId",
                table: "UserImages",
                column: "StoreLeaderId",
                principalTable: "StoreLeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
