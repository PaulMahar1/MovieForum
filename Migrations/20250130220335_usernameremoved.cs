﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieForum.Migrations
{
    /// <inheritdoc />
    public partial class usernameremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Discussion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Discussion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
