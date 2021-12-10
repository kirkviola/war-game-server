using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace war_game_server.Migrations
{
    public partial class playernamesunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cards_Name",
                table: "Cards",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cards_Name",
                table: "Cards");
        }
    }
}
