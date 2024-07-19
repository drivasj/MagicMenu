using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dishescategory",
                columns: table => new
                {
                    IdDishesCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishescategory", x => x.IdDishesCategory);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employeedetails",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Adress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeedetails", x => x.IdEmployee);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Restaurantdetails",
                columns: table => new
                {
                    IdRestaurant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TaxId = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantdetails", x => x.IdRestaurant);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Document = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmployeedetailsIdEmployee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employee_Employeedetails_EmployeedetailsIdEmployee",
                        column: x => x.EmployeedetailsIdEmployee,
                        principalTable: "Employeedetails",
                        principalColumn: "IdEmployee");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    IdRestaurant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    RegisterUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RestaurantdetailsIdRestaurant = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.IdRestaurant);
                    table.ForeignKey(
                        name: "FK_Restaurant_Restaurantdetails_RestaurantdetailsIdRestaurant",
                        column: x => x.RestaurantdetailsIdRestaurant,
                        principalTable: "Restaurantdetails",
                        principalColumn: "IdRestaurant");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    IdDishes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    IdDishesCategory = table.Column<int>(type: "int", nullable: false),
                    DishescategoryIdDishesCategory = table.Column<int>(type: "int", nullable: true),
                    IdRestaurant = table.Column<int>(type: "int", nullable: false),
                    RestaurantIdRestaurant = table.Column<int>(type: "int", nullable: true),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.IdDishes);
                    table.ForeignKey(
                        name: "FK_Dishes_Dishescategory_DishescategoryIdDishesCategory",
                        column: x => x.DishescategoryIdDishesCategory,
                        principalTable: "Dishescategory",
                        principalColumn: "IdDishesCategory");
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurant_RestaurantIdRestaurant",
                        column: x => x.RestaurantIdRestaurant,
                        principalTable: "Restaurant",
                        principalColumn: "IdRestaurant");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Restaurantemployee",
                columns: table => new
                {
                    IdRestaurantEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRestaurant = table.Column<int>(type: "int", nullable: false),
                    RestaurantIdRestaurant = table.Column<int>(type: "int", nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdateUser = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantemployee", x => x.IdRestaurantEmployee);
                    table.ForeignKey(
                        name: "FK_Restaurantemployee_Restaurant_RestaurantIdRestaurant",
                        column: x => x.RestaurantIdRestaurant,
                        principalTable: "Restaurant",
                        principalColumn: "IdRestaurant");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishescategoryIdDishesCategory",
                table: "Dishes",
                column: "DishescategoryIdDishesCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantIdRestaurant",
                table: "Dishes",
                column: "RestaurantIdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeedetailsIdEmployee",
                table: "Employee",
                column: "EmployeedetailsIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_RestaurantdetailsIdRestaurant",
                table: "Restaurant",
                column: "RestaurantdetailsIdRestaurant");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantemployee_RestaurantIdRestaurant",
                table: "Restaurantemployee",
                column: "RestaurantIdRestaurant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Restaurantemployee");

            migrationBuilder.DropTable(
                name: "Dishescategory");

            migrationBuilder.DropTable(
                name: "Employeedetails");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Restaurantdetails");
        }
    }
}
