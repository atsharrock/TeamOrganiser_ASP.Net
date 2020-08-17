using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class linkFootballPlayerToGamesAndTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballPlayerFootballGames",
                columns: table => new
                {
                    If = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootballPlayerId = table.Column<int>(nullable: false),
                    FootballGameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayerFootballGames", x => x.If);
                    table.ForeignKey(
                        name: "FK_FootballPlayerFootballGames_FootballGames_FootballGameId",
                        column: x => x.FootballGameId,
                        principalTable: "FootballGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballPlayerFootballGames_FootballPlayers_FootballPlayerId",
                        column: x => x.FootballPlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayerFootballTeams",
                columns: table => new
                {
                    If = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootballPlayerId = table.Column<int>(nullable: false),
                    FootballTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayerFootballTeams", x => x.If);
                    table.ForeignKey(
                        name: "FK_FootballPlayerFootballTeams_FootballPlayers_FootballPlayerId",
                        column: x => x.FootballPlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballPlayerFootballTeams_FootballTeams_FootballTeamId",
                        column: x => x.FootballTeamId,
                        principalTable: "FootballTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayerFootballGames_FootballGameId",
                table: "FootballPlayerFootballGames",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayerFootballGames_FootballPlayerId",
                table: "FootballPlayerFootballGames",
                column: "FootballPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayerFootballTeams_FootballPlayerId",
                table: "FootballPlayerFootballTeams",
                column: "FootballPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayerFootballTeams_FootballTeamId",
                table: "FootballPlayerFootballTeams",
                column: "FootballTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballPlayerFootballGames");

            migrationBuilder.DropTable(
                name: "FootballPlayerFootballTeams");
        }
    }
}
