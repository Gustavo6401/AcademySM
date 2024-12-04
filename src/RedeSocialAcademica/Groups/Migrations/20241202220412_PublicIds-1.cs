using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groups.Migrations
{
    /// <inheritdoc />
    public partial class PublicIds1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<Guid>(
                name: "PublicId",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PublicId",
                table: "Courses",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_PublicId",
                table: "Assignments",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_PublicId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_PublicId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Assignments");
        }
    }
}
