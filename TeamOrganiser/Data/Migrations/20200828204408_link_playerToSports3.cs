using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class link_playerToSports3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersSports");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Sports",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PlayersSports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    SportId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_PlayersSports_PlayerId",
                table: "PlayersSports",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersSports_SportId",
                table: "PlayersSports",
                column: "SportId");
        }
    }
}
