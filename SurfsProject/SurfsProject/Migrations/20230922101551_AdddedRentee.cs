using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedRentee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rentee",
                table: "Surfboard",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rentee",
                table: "Surfboard");
        }
    }
}
