using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class updatefootballgame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Team",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FootballTeamId",
                table: "Player",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "FootballGame",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.CreateIndex(
                name: "IX_Player_FootballTeamId",
                table: "Player",
                column: "FootballTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_FootballTeamId",
                table: "Player",
                column: "FootballTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_FootballTeamId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_FootballTeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "FootballTeamId",
                table: "Player");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "FootballGame",
                type: "time",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
