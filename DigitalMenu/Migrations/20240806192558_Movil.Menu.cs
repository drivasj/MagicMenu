using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class MovilMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Movil",
                table: "Menu",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movil",
                table: "Menu");
        }
    }
}
