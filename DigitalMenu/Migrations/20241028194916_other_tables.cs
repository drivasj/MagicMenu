using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class other_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_ProductDetails_ProductId",
            //    table: "ProductDetails");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameCountry = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CodeCountry = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoleCompany",
                columns: table => new
                {
                    IdRoleCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameRoleCompany = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleCompany", x => x.IdRoleCompany);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Typedocument",
                columns: table => new
                {
                    IdTypeDocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameDocument = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typedocument", x => x.IdTypeDocument);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameState = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CodeState = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameCompany = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    TaxId = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CenterDistribution = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompanyFather = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RoleCompanyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RegisterUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.IdCompany);
                    table.ForeignKey(
                        name: "FK_Company_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_RoleCompany_RoleCompanyId",
                        column: x => x.RoleCompanyId,
                        principalTable: "RoleCompany",
                        principalColumn: "IdRoleCompany",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Alias = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    NumberClient = table.Column<int>(type: "int", nullable: false),
                    TypeDocumentId = table.Column<int>(type: "int", nullable: false),
                    document = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RegisterUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_Typedocument_TypeDocumentId",
                        column: x => x.TypeDocumentId,
                        principalTable: "Typedocument",
                        principalColumn: "IdTypeDocument",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameCity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    IdCompanyDetails = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LogoUrl = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    Web = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    Intranet = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    Facebook = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    Twitter = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    Youtube = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    Instagram = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.IdCompanyDetails);
                    table.ForeignKey(
                        name: "FK_CompanyDetails_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    CompanyEmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RegisterUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => x.CompanyEmployeeId);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    IdClientDetails = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Street = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Reference = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Ext = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.IdClientDetails);
                    table.ForeignKey(
                        name: "FK_ClientDetails_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDetails_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductDetails_ProductId",
            //    table: "ProductDetails",
            //    column: "ProductId",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TypeDocumentId",
                table: "Client",
                column: "TypeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetails_CityId",
                table: "ClientDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDetails_ClientId",
                table: "ClientDetails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CountryId",
                table: "Company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_RoleCompanyId",
                table: "Company",
                column: "RoleCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_CompanyId",
                table: "CompanyDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_CompanyId",
                table: "CompanyEmployee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeeId",
                table: "CompanyEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Typedocument");

            migrationBuilder.DropTable(
                name: "RoleCompany");

            migrationBuilder.DropTable(
                name: "Country");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProductDetails_ProductId",
            //    table: "ProductDetails");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductDetails_ProductId",
            //    table: "ProductDetails",
            //    column: "ProductId");
        }
    }
}
