using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Groups.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarFotoPerfilUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funds",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicFilePath",
                table: "User",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicFilePath",
                table: "User");

            migrationBuilder.AddColumn<decimal>(
                name: "Funds",
                table: "User",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
