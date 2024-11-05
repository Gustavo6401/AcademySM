using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroUsuario.Migrations
{
    /// <inheritdoc />
    public partial class PrivacyPolicyUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConsentCookies",
                table: "ApplicationUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ConsentPrivacyPolicy",
                table: "ApplicationUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsentCookies",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "ConsentPrivacyPolicy",
                table: "ApplicationUser");
        }
    }
}
