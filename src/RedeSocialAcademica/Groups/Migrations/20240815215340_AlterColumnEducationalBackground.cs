using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groups.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnEducationalBackground : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroups_Courses_GroupsId",
                table: "CategoryGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups");

            migrationBuilder.DropIndex(
                name: "IX_CategoryGroups_GroupsId",
                table: "CategoryGroups");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                table: "CategoryGroups");

            migrationBuilder.AlterColumn<string>(
                name: "EducationalBackground",
                table: "User",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups",
                columns: new[] { "CategoryId", "GroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_GroupId",
                table: "CategoryGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroups_Courses_GroupId",
                table: "CategoryGroups",
                column: "GroupId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryGroups_Courses_GroupId",
                table: "CategoryGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups");

            migrationBuilder.DropIndex(
                name: "IX_CategoryGroups_GroupId",
                table: "CategoryGroups");

            migrationBuilder.AlterColumn<string>(
                name: "EducationalBackground",
                table: "User",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupsId",
                table: "CategoryGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups",
                columns: new[] { "CategoryId", "GroupsId" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGroups_GroupsId",
                table: "CategoryGroups",
                column: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryGroups_Courses_GroupsId",
                table: "CategoryGroups",
                column: "GroupsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
