using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsProject.Migrations
{
    /// <inheritdoc />
    public partial class LoginOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LoginOnly",
                table: "Surfboard",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginOnly",
                table: "Surfboard");
        }
    }
}
