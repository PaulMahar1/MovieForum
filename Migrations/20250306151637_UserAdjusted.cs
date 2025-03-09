using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieForum.Migrations
{
    /// <inheritdoc />
    public partial class UserAdjusted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForHire",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "AspNetUsers",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "ImageFilename",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilename",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "AspNetUsers",
                newName: "Bio");

            migrationBuilder.AddColumn<bool>(
                name: "IsForHire",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
