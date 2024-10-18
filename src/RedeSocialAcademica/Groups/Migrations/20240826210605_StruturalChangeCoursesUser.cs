using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groups.Migrations
{
    /// <inheritdoc />
    public partial class StruturalChangeCoursesUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsUsers_Courses_CoursesId",
                table: "GroupsUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupsUsers_CoursesId",
                table: "GroupsUsers");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "GroupsUsers");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_GroupId",
                table: "GroupsUsers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Courses_GroupId",
                table: "GroupsUsers",
                column: "GroupId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupsUsers_Courses_GroupId",
                table: "GroupsUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupsUsers_GroupId",
                table: "GroupsUsers");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "GroupsUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_CoursesId",
                table: "GroupsUsers",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsUsers_Courses_CoursesId",
                table: "GroupsUsers",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
