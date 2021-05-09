using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class Items1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contract",
                newName: "IX_Contract_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "DateStart",
                table: "Contract",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DateEnd",
                table: "Contract",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Datecreate = table.Column<string>(maxLength: 100, nullable: false),
                    Datemod = table.Column<string>(maxLength: 100, nullable: false),
                    Usucreo = table.Column<string>(maxLength: 500, nullable: true),
                    Usermod = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 35, nullable: false),
                    LifeUse = table.Column<int>(nullable: false),
                    Otros = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Datecreate = table.Column<string>(maxLength: 100, nullable: false),
                    Datemod = table.Column<string>(maxLength: 100, nullable: false),
                    Usucreo = table.Column<string>(maxLength: 500, nullable: true),
                    Usermod = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Datecreate = table.Column<string>(maxLength: 100, nullable: false),
                    Datemod = table.Column<string>(maxLength: 100, nullable: false),
                    Usucreo = table.Column<string>(maxLength: 500, nullable: true),
                    Usermod = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Datecreate = table.Column<string>(maxLength: 100, nullable: false),
                    Datemod = table.Column<string>(maxLength: 100, nullable: false),
                    Usucreo = table.Column<string>(maxLength: 500, nullable: true),
                    Usermod = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Datecreate = table.Column<string>(maxLength: 100, nullable: false),
                    Datemod = table.Column<string>(maxLength: 100, nullable: false),
                    Usucreo = table.Column<string>(maxLength: 500, nullable: true),
                    Usermod = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Di = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Serial = table.Column<string>(maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Datepurchase = table.Column<string>(nullable: false),
                    UnitValue = table.Column<double>(nullable: false),
                    Coment = table.Column<string>(maxLength: 200, nullable: false),
                    Dateitemcreate = table.Column<string>(nullable: false),
                    DateMod = table.Column<string>(nullable: false),
                    TimeGarant = table.Column<int>(maxLength: 200, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    Usucreate = table.Column<string>(nullable: true),
                    Usermod = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    FabricId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FabricId",
                table: "Items",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ModelId",
                table: "Items",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProviderId",
                table: "Items",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Employees_EmployeeId",
                table: "Contract",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Employees_EmployeeId",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_EmployeeId",
                table: "Contracts",
                newName: "IX_Contracts_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "DateStart",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DateEnd",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
