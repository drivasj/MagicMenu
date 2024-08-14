using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class RoleModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IX_Roleuser_RoleId",
                table: "Roleuser");

            migrationBuilder.CreateIndex(
                name: "IX_Roleuser_RoleId",
                table: "Roleuser",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roleuser_RoleId",
                table: "Roleuser");

            migrationBuilder.CreateIndex(
                name: "IX_Roleuser_RoleId",
                table: "Roleuser",
                column: "RoleId",
                unique: true);
        }
    }
}
