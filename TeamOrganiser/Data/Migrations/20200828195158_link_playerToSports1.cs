using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class link_playerToSports1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Sports_FootballGameId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_FootballTeamId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_PlayerId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "AttackingMidfield",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CentreBack",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CentreForward",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CentreMidfield",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "DefensiveMidfield",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "FootballGameId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "FootballTeamId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Forward",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "FullBack",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Midfield",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Sweeper",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "WideMidfield",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "WingBack",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Winger",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Sports");

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Defence = table.Column<int>(nullable: false),
                    CentreBack = table.Column<int>(nullable: false),
                    Sweeper = table.Column<int>(nullable: false),
                    FullBack = table.Column<int>(nullable: false),
                    WingBack = table.Column<int>(nullable: false),
                    Midfield = table.Column<int>(nullable: false),
                    CentreMidfield = table.Column<int>(nullable: false),
                    DefensiveMidfield = table.Column<int>(nullable: false),
                    AttackingMidfield = table.Column<int>(nullable: false),
                    WideMidfield = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Forward = table.Column<int>(nullable: false),
                    CentreForward = table.Column<int>(nullable: false),
                    Winger = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    FootballGameId = table.Column<int>(nullable: true),
                    FootballTeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballGames_FootballGameId",
                        column: x => x.FootballGameId,
                        principalTable: "FootballGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballTeams_FootballTeamId",
                        column: x => x.FootballTeamId,
                        principalTable: "FootballTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballGameId",
                table: "FootballPlayers",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballTeamId",
                table: "FootballPlayers",
                column: "FootballTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_PlayerId",
                table: "FootballPlayers",
                column: "PlayerId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayerFootballGames_FootballPlayers_FootballPlayerId",
                table: "FootballPlayerFootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayerFootballTeams_FootballPlayers_FootballPlayerId",
                table: "FootballPlayerFootballTeams");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttackingMidfield",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreBack",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreForward",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreMidfield",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefensiveMidfield",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FootballGameId",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FootballTeamId",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Forward",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullBack",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Midfield",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sweeper",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WideMidfield",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WingBack",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Winger",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_FootballGameId",
                table: "Sports",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_FootballTeamId",
                table: "Sports",
                column: "FootballTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_PlayerId",
                table: "Sports",
                column: "PlayerId");

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
    }
}
