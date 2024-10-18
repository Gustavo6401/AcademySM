using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groups.Migrations
{
    /// <inheritdoc />
    public partial class BenefitsForParticularTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Courses");
        }
    }
}
