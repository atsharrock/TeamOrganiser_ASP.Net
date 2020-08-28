using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class link_playerToSports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayerFootballGames_FootballPlayers_FootballPlayerId",
                table: "FootballPlayerFootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayerFootballTeams_FootballPlayers_FootballPlayerId",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_FootballGames_FootballGameId",
                table: "FootballPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_FootballTeams_FootballTeamId",
                table: "FootballPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballPlayers",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "Basketball",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Football",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Hockey",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "FootballPlayers",
                newName: "Sports");

            migrationBuilder.RenameIndex(
                name: "IX_FootballPlayers_FootballTeamId",
                table: "Sports",
                newName: "IX_Sports_FootballTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballPlayers_FootballGameId",
                table: "Sports",
                newName: "IX_Sports_FootballGameId");

            migrationBuilder.AlterColumn<int>(
                name: "Winger",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WingBack",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WideMidfield",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Sweeper",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Midfield",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FullBack",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Forward",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DefensiveMidfield",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Defence",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CentreMidfield",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CentreForward",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CentreBack",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttackingMidfield",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Attack",
                table: "Sports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Sports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Sports",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sports",
                table: "Sports",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlayersSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: true),
                    SportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersSports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersSports_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersSports_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sports_PlayerId",
                table: "Sports",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersSports_PlayerId",
                table: "PlayersSports",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersSports_SportId",
                table: "PlayersSports",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayerFootballGames_Sports_FootballPlayerId",
                table: "FootballPlayerFootballGames",
                column: "FootballPlayerId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayerFootballTeams_Sports_FootballPlayerId",
                table: "FootballPlayerFootballTeams",
                column: "FootballPlayerId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_FootballGames_FootballGameId",
                table: "Sports",
                column: "FootballGameId",
                principalTable: "FootballGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_FootballTeams_FootballTeamId",
                table: "Sports",
                column: "FootballTeamId",
                principalTable: "FootballTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Players_PlayerId",
                table: "Sports",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayerFootballGames_Sports_FootballPlayerId",
                table: "FootballPlayerFootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayerFootballTeams_Sports_FootballPlayerId",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_FootballGames_FootballGameId",
                table: "Sports");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_FootballTeams_FootballTeamId",
                table: "Sports");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Players_PlayerId",
                table: "Sports");

            migrationBuilder.DropTable(
                name: "PlayersSports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sports",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_PlayerId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Sports");

            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "FootballPlayers");

            migrationBuilder.RenameIndex(
                name: "IX_Sports_FootballTeamId",
                table: "FootballPlayers",
                newName: "IX_FootballPlayers_FootballTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Sports_FootballGameId",
                table: "FootballPlayers",
                newName: "IX_FootballPlayers_FootballGameId");

            migrationBuilder.AddColumn<bool>(
                name: "Basketball",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Football",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hockey",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Winger",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WingBack",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WideMidfield",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Sweeper",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Midfield",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FullBack",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Forward",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefensiveMidfield",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Defence",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CentreMidfield",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CentreForward",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CentreBack",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttackingMidfield",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Attack",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballPlayers",
                table: "FootballPlayers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayerFootballGames_FootballPlayers_FootballPlayerId",
                table: "FootballPlayerFootballGames",
                column: "FootballPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayerFootballTeams_FootballPlayers_FootballPlayerId",
                table: "FootballPlayerFootballTeams",
                column: "FootballPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_FootballGames_FootballGameId",
                table: "FootballPlayers",
                column: "FootballGameId",
                principalTable: "FootballGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_FootballTeams_FootballTeamId",
                table: "FootballPlayers",
                column: "FootballTeamId",
                principalTable: "FootballTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
