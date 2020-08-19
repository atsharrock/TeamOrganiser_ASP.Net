using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayerFootballGames",
                table: "FootballPlayerFootballGames");

            migrationBuilder.DropColumn(
                name: "If",
                table: "FootballPlayerFootballGames");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FootballPlayerFootballGames",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayerFootballGames",
                table: "FootballPlayerFootballGames",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayerFootballGames",
                table: "FootballPlayerFootballGames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FootballPlayerFootballGames");

            migrationBuilder.AddColumn<int>(
                name: "If",
                table: "FootballPlayerFootballGames",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayerFootballGames",
                table: "FootballPlayerFootballGames",
                column: "If");
        }
    }
}
