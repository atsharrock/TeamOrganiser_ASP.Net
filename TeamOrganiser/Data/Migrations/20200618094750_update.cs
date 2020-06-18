using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_Team_FootballTeamId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_Team_WinnerId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_Team_FootballTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_FootballGames_FootballGameId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_FootballPlayers_FootballPlayerId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_FootballGames_FootballTeamId",
                table: "FootballGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_FootballPlayerId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FootballTeamId",
                table: "FootballGames");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FootballPlayerId",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "FootballTeams");

            migrationBuilder.RenameIndex(
                name: "IX_Team_FootballGameId",
                table: "FootballTeams",
                newName: "IX_FootballTeams_FootballGameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballTeams",
                table: "FootballTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGames_FootballTeams_WinnerId",
                table: "FootballGames",
                column: "WinnerId",
                principalTable: "FootballTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_FootballTeams_FootballTeamId",
                table: "FootballPlayers",
                column: "FootballTeamId",
                principalTable: "FootballTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballTeams_FootballGames_FootballGameId",
                table: "FootballTeams",
                column: "FootballGameId",
                principalTable: "FootballGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_FootballTeams_WinnerId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_FootballTeams_FootballTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballTeams_FootballGames_FootballGameId",
                table: "FootballTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballTeams",
                table: "FootballTeams");

            migrationBuilder.RenameTable(
                name: "FootballTeams",
                newName: "Team");

            migrationBuilder.RenameIndex(
                name: "IX_FootballTeams_FootballGameId",
                table: "Team",
                newName: "IX_Team_FootballGameId");

            migrationBuilder.AddColumn<int>(
                name: "FootballTeamId",
                table: "FootballGames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FootballPlayerId",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGames_FootballTeamId",
                table: "FootballGames",
                column: "FootballTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_FootballPlayerId",
                table: "Team",
                column: "FootballPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGames_Team_FootballTeamId",
                table: "FootballGames",
                column: "FootballTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGames_Team_WinnerId",
                table: "FootballGames",
                column: "WinnerId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_Team_FootballTeamId",
                table: "FootballPlayers",
                column: "FootballTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_FootballGames_FootballGameId",
                table: "Team",
                column: "FootballGameId",
                principalTable: "FootballGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_FootballPlayers_FootballPlayerId",
                table: "Team",
                column: "FootballPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
