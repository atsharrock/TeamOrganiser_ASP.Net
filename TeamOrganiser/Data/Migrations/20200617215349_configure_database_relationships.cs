using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class configure_database_relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballGame_Team_TeamAId",
                table: "FootballGame");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGame_Team_TeamBId",
                table: "FootballGame");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGame_Team_WinnerId",
                table: "FootballGame");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_FootballGame_FootballGameId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_FootballTeamId",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballGame",
                table: "FootballGame");

            migrationBuilder.DropIndex(
                name: "IX_FootballGame_TeamAId",
                table: "FootballGame");

            migrationBuilder.DropIndex(
                name: "IX_FootballGame_TeamBId",
                table: "FootballGame");

            migrationBuilder.DropColumn(
                name: "TeamAId",
                table: "FootballGame");

            migrationBuilder.DropColumn(
                name: "TeamBId",
                table: "FootballGame");

            migrationBuilder.RenameTable(
                name: "UserAccount",
                newName: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "FootballGame",
                newName: "FootballGames");

            migrationBuilder.RenameIndex(
                name: "IX_Player_FootballTeamId",
                table: "Players",
                newName: "IX_Players_FootballTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_FootballGameId",
                table: "Players",
                newName: "IX_Players_FootballGameId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballGame_WinnerId",
                table: "FootballGames",
                newName: "IX_FootballGames_WinnerId");

            migrationBuilder.AddColumn<int>(
                name: "FootballGameId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FootballPlayerId",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FootballTeamId",
                table: "FootballGames",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballGames",
                table: "FootballGames",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Team_FootballGameId",
                table: "Team",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_FootballPlayerId",
                table: "Team",
                column: "FootballPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGames_FootballTeamId",
                table: "FootballGames",
                column: "FootballTeamId");

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
                name: "FK_Players_FootballGames_FootballGameId",
                table: "Players",
                column: "FootballGameId",
                principalTable: "FootballGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Team_FootballTeamId",
                table: "Players",
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
                name: "FK_Team_Players_FootballPlayerId",
                table: "Team",
                column: "FootballPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_Team_FootballTeamId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_Team_WinnerId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_FootballGames_FootballGameId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Team_FootballTeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_FootballGames_FootballGameId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Players_FootballPlayerId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_FootballGameId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_FootballPlayerId",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballGames",
                table: "FootballGames");

            migrationBuilder.DropIndex(
                name: "IX_FootballGames_FootballTeamId",
                table: "FootballGames");

            migrationBuilder.DropColumn(
                name: "FootballGameId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FootballPlayerId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FootballTeamId",
                table: "FootballGames");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "UserAccount");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "FootballGames",
                newName: "FootballGame");

            migrationBuilder.RenameIndex(
                name: "IX_Players_FootballTeamId",
                table: "Player",
                newName: "IX_Player_FootballTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_FootballGameId",
                table: "Player",
                newName: "IX_Player_FootballGameId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballGames_WinnerId",
                table: "FootballGame",
                newName: "IX_FootballGame_WinnerId");

            migrationBuilder.AddColumn<int>(
                name: "TeamAId",
                table: "FootballGame",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamBId",
                table: "FootballGame",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballGame",
                table: "FootballGame",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_TeamAId",
                table: "FootballGame",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_TeamBId",
                table: "FootballGame",
                column: "TeamBId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGame_Team_TeamAId",
                table: "FootballGame",
                column: "TeamAId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGame_Team_TeamBId",
                table: "FootballGame",
                column: "TeamBId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGame_Team_WinnerId",
                table: "FootballGame",
                column: "WinnerId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_FootballGame_FootballGameId",
                table: "Player",
                column: "FootballGameId",
                principalTable: "FootballGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_FootballTeamId",
                table: "Player",
                column: "FootballTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
