using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class link_playerToSports2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_Players_PlayerId",
                table: "FootballPlayers");

            migrationBuilder.DropIndex(
                name: "IX_FootballPlayers_PlayerId",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "FootballPlayers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_PlayerId",
                table: "FootballPlayers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_Players_PlayerId",
                table: "FootballPlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
