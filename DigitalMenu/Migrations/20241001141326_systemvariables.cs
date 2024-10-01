using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class systemvariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Typesystemvariable",
                columns: table => new
                {
                    IdTypesystemvariable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typesystemvariable", x => x.IdTypesystemvariable);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Systemvariable",
                columns: table => new
                {
                    IdSystemVariable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TypesystemvariableId = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ValueString = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ValueNumeric = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegisterUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systemvariable", x => x.IdSystemVariable);
                    table.ForeignKey(
                        name: "FK_Systemvariable_Typesystemvariable_TypesystemvariableId",
                        column: x => x.TypesystemvariableId,
                        principalTable: "Typesystemvariable",
                        principalColumn: "IdTypesystemvariable",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Systemvariable_TypesystemvariableId",
                table: "Systemvariable",
                column: "TypesystemvariableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Systemvariable");

            migrationBuilder.DropTable(
                name: "Typesystemvariable");
        }
    }
}
