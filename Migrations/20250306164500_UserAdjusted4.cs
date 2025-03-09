using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieForum.Migrations
{
    /// <inheritdoc />
    public partial class UserAdjusted4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForHire",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Discussion",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_ApplicationUserId",
                table: "Discussion",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_ApplicationUserId",
                table: "Discussion",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_ApplicationUserId",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_ApplicationUserId",
                table: "Discussion");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Discussion",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsForHire",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
