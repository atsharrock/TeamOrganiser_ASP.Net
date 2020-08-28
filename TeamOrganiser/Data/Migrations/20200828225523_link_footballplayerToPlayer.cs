using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class link_footballplayerToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FootballPlayers");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "FootballPlayers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "FootballPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FootballPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FootballPlayers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FootballPlayers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
