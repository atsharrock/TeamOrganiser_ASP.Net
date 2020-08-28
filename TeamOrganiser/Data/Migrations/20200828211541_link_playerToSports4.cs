using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class link_playerToSports4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Players_PlayerId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_PlayerId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Sports");

            migrationBuilder.CreateTable(
                name: "PlayerSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    SportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSports_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSports_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSports_PlayerId",
                table: "PlayerSports",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSports_SportId",
                table: "PlayerSports",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSports");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_PlayerId",
                table: "Sports",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Players_PlayerId",
                table: "Sports",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
