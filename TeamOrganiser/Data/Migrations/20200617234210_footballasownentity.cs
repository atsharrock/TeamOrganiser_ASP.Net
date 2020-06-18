using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class footballasownentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_FootballGames_FootballGameId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Team_FootballTeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Players_FootballPlayerId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Players_FootballGameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_FootballTeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AttackingMidfield",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CentreBack",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CentreForward",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CentreMidfield",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DefensiveMidfield",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FootballGameId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FootballTeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Forward",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FullBack",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Midfield",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Sweeper",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WideMidfield",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WingBack",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Winger",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
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
                        name: "FK_FootballPlayers_Team_FootballTeamId",
                        column: x => x.FootballTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballGameId",
                table: "FootballPlayers",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballTeamId",
                table: "FootballPlayers",
                column: "FootballTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_FootballPlayers_FootballPlayerId",
                table: "Team",
                column: "FootballPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_FootballPlayers_FootballPlayerId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttackingMidfield",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreBack",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreForward",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreMidfield",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefensiveMidfield",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FootballGameId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FootballTeamId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Forward",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullBack",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Midfield",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sweeper",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WideMidfield",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WingBack",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Winger",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_FootballGameId",
                table: "Players",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_FootballTeamId",
                table: "Players",
                column: "FootballTeamId");

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
                name: "FK_Team_Players_FootballPlayerId",
                table: "Team",
                column: "FootballPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
