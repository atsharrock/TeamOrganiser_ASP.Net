using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class Footballgame_playerlist_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FootballGameId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_FootballGameId",
                table: "Player",
                column: "FootballGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_FootballGame_FootballGameId",
                table: "Player",
                column: "FootballGameId",
                principalTable: "FootballGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_FootballGame_FootballGameId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_FootballGameId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "FootballGameId",
                table: "Player");
        }
    }
}
