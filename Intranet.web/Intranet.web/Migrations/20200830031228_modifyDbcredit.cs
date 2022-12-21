using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class modifyDbcredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Purchasings_purchasingId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Endowments_Purchasings_purchasingId",
                table: "Endowments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Purchasings_purchasingId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonContacts_Purchasings_purchasingId",
                table: "PersonContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_Areas_AreaId",
                table: "Purchasings");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_Eps_EpsId",
                table: "Purchasings");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_Pensions_PensionId",
                table: "Purchasings");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_PositionEmployees_PositionEmployeeId",
                table: "Purchasings");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasings_CajaCompensacions_cajaCompensacionId",
                table: "Purchasings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sons_Purchasings_purchasingId",
                table: "Sons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_Purchasings_purchasingId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_purchasingId",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_Sons_purchasingId",
                table: "Sons");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_AreaId",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_EpsId",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_PensionId",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_PositionEmployeeId",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_Purchasings_cajaCompensacionId",
                table: "Purchasings");

            migrationBuilder.DropIndex(
                name: "IX_PersonContacts_purchasingId",
                table: "PersonContacts");

            migrationBuilder.DropIndex(
                name: "IX_Exams_purchasingId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Endowments_purchasingId",
                table: "Endowments");

            migrationBuilder.DropIndex(
                name: "IX_Credits_purchasingId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "purchasingId",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "purchasingId",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "EpsId",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "PensionId",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "PositionEmployeeId",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "cajaCompensacionId",
                table: "Purchasings");

            migrationBuilder.DropColumn(
                name: "purchasingId",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "purchasingId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "purchasingId",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "purchasingId",
                table: "Credits");

            migrationBuilder.AlterColumn<string>(
                name: "UserRegistra",
                table: "Sons",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "Credits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "Credits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Credits",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "Credits",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "Credits");

            migrationBuilder.AddColumn<int>(
                name: "purchasingId",
                table: "UserImages",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRegistra",
                table: "Sons",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "purchasingId",
                table: "Sons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Purchasings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpsId",
                table: "Purchasings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PensionId",
                table: "Purchasings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionEmployeeId",
                table: "Purchasings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cajaCompensacionId",
                table: "Purchasings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "purchasingId",
                table: "PersonContacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "purchasingId",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "purchasingId",
                table: "Endowments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "purchasingId",
                table: "Credits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_purchasingId",
                table: "UserImages",
                column: "purchasingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sons_purchasingId",
                table: "Sons",
                column: "purchasingId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_AreaId",
                table: "Purchasings",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_EpsId",
                table: "Purchasings",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_PensionId",
                table: "Purchasings",
                column: "PensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_PositionEmployeeId",
                table: "Purchasings",
                column: "PositionEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasings_cajaCompensacionId",
                table: "Purchasings",
                column: "cajaCompensacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_purchasingId",
                table: "PersonContacts",
                column: "purchasingId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_purchasingId",
                table: "Exams",
                column: "purchasingId");

            migrationBuilder.CreateIndex(
                name: "IX_Endowments_purchasingId",
                table: "Endowments",
                column: "purchasingId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_purchasingId",
                table: "Credits",
                column: "purchasingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Purchasings_purchasingId",
                table: "Credits",
                column: "purchasingId",
                principalTable: "Purchasings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endowments_Purchasings_purchasingId",
                table: "Endowments",
                column: "purchasingId",
                principalTable: "Purchasings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Purchasings_purchasingId",
                table: "Exams",
                column: "purchasingId",
                principalTable: "Purchasings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContacts_Purchasings_purchasingId",
                table: "PersonContacts",
                column: "purchasingId",
                principalTable: "Purchasings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_Areas_AreaId",
                table: "Purchasings",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_Eps_EpsId",
                table: "Purchasings",
                column: "EpsId",
                principalTable: "Eps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_Pensions_PensionId",
                table: "Purchasings",
                column: "PensionId",
                principalTable: "Pensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_PositionEmployees_PositionEmployeeId",
                table: "Purchasings",
                column: "PositionEmployeeId",
                principalTable: "PositionEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasings_CajaCompensacions_cajaCompensacionId",
                table: "Purchasings",
                column: "cajaCompensacionId",
                principalTable: "CajaCompensacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sons_Purchasings_purchasingId",
                table: "Sons",
                column: "purchasingId",
                principalTable: "Purchasings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_Purchasings_purchasingId",
                table: "UserImages",
                column: "purchasingId",
                principalTable: "Purchasings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
