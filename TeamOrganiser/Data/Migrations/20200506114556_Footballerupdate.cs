using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class Footballerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "FootballPlayer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "FootballPlayer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "FootballPlayer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FootballPlayer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FootballPlayer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FootballPlayer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Midfield",
                table: "FootballPlayer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attack",
                table: "FootballPlayer");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "FootballPlayer");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "FootballPlayer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "FootballPlayer");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FootballPlayer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FootballPlayer");

            migrationBuilder.DropColumn(
                name: "Midfield",
                table: "FootballPlayer");
        }
    }
}
