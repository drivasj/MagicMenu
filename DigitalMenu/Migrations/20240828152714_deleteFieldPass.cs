﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMenu.Migrations
{
    /// <inheritdoc />
    public partial class deleteFieldPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
