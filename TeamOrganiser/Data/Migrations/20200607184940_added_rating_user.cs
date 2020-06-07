using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class added_rating_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Player",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Player");
        }
    }
}
