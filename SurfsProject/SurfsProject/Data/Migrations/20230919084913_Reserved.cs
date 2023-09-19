using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsProject.Migrations
{
    /// <inheritdoc />
    public partial class Reserved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "Surfboard",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "Surfboard");
        }
    }
}
