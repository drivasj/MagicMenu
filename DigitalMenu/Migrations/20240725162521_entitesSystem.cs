using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class entitesSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    IdApplication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Display = table.Column<string>(type: "longtext", nullable: true),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.IdApplication);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Privilege = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NameRoleNotification = table.Column<string>(type: "longtext", nullable: true),
                    TimeInitial = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    TimeFinal = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRole);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Online = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserTelegram = table.Column<string>(type: "longtext", nullable: true),
                    ChatIdTelegram = table.Column<long>(type: "bigint", nullable: false),
                    PasswordUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NotificationPush = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    IdMenu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdApplication = table.Column<int>(type: "int", nullable: false),
                    applicationIdApplication = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<string>(type: "longtext", nullable: true),
                    Controller = table.Column<string>(type: "longtext", nullable: true),
                    Action = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegisterUser = table.Column<string>(type: "longtext", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.IdMenu);
                    table.ForeignKey(
                        name: "FK_Menu_Application_applicationIdApplication",
                        column: x => x.applicationIdApplication,
                        principalTable: "Application",
                        principalColumn: "IdApplication");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roleuser",
                columns: table => new
                {
                    IdRoleUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    roleIdRole = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    userIdUser = table.Column<int>(type: "int", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roleuser", x => x.IdRoleUser);
                    table.ForeignKey(
                        name: "FK_Roleuser_Role_roleIdRole",
                        column: x => x.roleIdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole");
                    table.ForeignKey(
                        name: "FK_Roleuser_User_userIdUser",
                        column: x => x.userIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rolemenu",
                columns: table => new
                {
                    IdRoleMenu = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    roleIdRole = table.Column<int>(type: "int", nullable: true),
                    IdMenu = table.Column<int>(type: "int", nullable: false),
                    menuIdMenu = table.Column<int>(type: "int", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "longtext", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolemenu", x => x.IdRoleMenu);
                    table.ForeignKey(
                        name: "FK_Rolemenu_Menu_menuIdMenu",
                        column: x => x.menuIdMenu,
                        principalTable: "Menu",
                        principalColumn: "IdMenu");
                    table.ForeignKey(
                        name: "FK_Rolemenu_Role_roleIdRole",
                        column: x => x.roleIdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_applicationIdApplication",
                table: "Menu",
                column: "applicationIdApplication");

            migrationBuilder.CreateIndex(
                name: "IX_Rolemenu_menuIdMenu",
                table: "Rolemenu",
                column: "menuIdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_Rolemenu_roleIdRole",
                table: "Rolemenu",
                column: "roleIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Roleuser_roleIdRole",
                table: "Roleuser",
                column: "roleIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Roleuser_userIdUser",
                table: "Roleuser",
                column: "userIdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rolemenu");

            migrationBuilder.DropTable(
                name: "Roleuser");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Application");
        }
    }
}
