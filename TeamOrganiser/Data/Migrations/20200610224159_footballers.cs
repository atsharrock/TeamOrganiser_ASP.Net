using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class footballers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Player",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamRating = table.Column<int>(nullable: false),
                    TeamChemistry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamAId = table.Column<int>(nullable: true),
                    TeamBId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    WinnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballGame_Team_TeamAId",
                        column: x => x.TeamAId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballGame_Team_TeamBId",
                        column: x => x.TeamBId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballGame_Team_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_TeamAId",
                table: "FootballGame",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_TeamBId",
                table: "FootballGame",
                column: "TeamBId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_WinnerId",
                table: "FootballGame",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropTable(
                name: "FootballGame");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Player");
        }
    }
}
