using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamOrganiser.Data.Migrations
{
    public partial class edit_FootballPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballPlayer");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttackingMidfield",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreBack",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreForward",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CentreMidfield",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefensiveMidfield",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Forward",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullBack",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Midfield",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sweeper",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WideMidfield",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WingBack",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Winger",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Player",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "AttackingMidfield",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "CentreBack",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "CentreForward",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "CentreMidfield",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "DefensiveMidfield",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Forward",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "FullBack",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Midfield",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Sweeper",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "WideMidfield",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "WingBack",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Winger",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Player");

            migrationBuilder.CreateTable(
                name: "FootballPlayer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    AttackingMidfield = table.Column<int>(type: "int", nullable: false),
                    CentreBack = table.Column<int>(type: "int", nullable: false),
                    CentreForward = table.Column<int>(type: "int", nullable: false),
                    CentreMidfield = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    DefensiveMidfield = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Forward = table.Column<int>(type: "int", nullable: false),
                    FullBack = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Midfield = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Sweeper = table.Column<int>(type: "int", nullable: false),
                    WideMidfield = table.Column<int>(type: "int", nullable: false),
                    WingBack = table.Column<int>(type: "int", nullable: false),
                    Winger = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayer", x => x.ID);
                });
        }
    }
}
