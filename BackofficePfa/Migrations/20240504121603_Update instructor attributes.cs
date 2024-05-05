using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackofficePfa.Migrations
{
    /// <inheritdoc />
    public partial class Updateinstructorattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NightClasses",
                table: "Instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NightClasses",
                table: "Instructors");
        }
    }
}
