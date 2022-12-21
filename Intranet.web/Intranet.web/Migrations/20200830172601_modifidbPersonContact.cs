using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class modifidbPersonContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "PersonContacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "PersonContacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "PersonContacts",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "PersonContacts",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "Endowments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "Endowments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Endowments",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "Endowments",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "PersonContacts");

            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Endowments");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "Endowments");
        }
    }
}
