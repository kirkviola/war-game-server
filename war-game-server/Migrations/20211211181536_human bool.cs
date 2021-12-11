using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace war_game_server.Migrations
{
    public partial class humanbool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHuman",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHuman",
                table: "Players");
        }
    }
}
