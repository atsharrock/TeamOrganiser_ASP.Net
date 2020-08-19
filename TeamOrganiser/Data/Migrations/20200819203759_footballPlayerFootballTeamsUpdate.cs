using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class footballPlayerFootballTeamsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayerFootballTeams",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.DropColumn(
                name: "If",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FootballPlayerFootballTeams",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayerFootballTeams",
                table: "FootballPlayerFootballTeams",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayerFootballTeams",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.AddColumn<int>(
                name: "If",
                table: "FootballPlayerFootballTeams",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayerFootballTeams",
                table: "FootballPlayerFootballTeams",
                column: "If");
        }
    }
}
