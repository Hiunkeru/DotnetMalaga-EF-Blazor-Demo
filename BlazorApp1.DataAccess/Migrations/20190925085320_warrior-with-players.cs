using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.DataAccess.Migrations
{
    public partial class warriorwithplayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Player_WarriorId",
                table: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_Player_WarriorId",
                table: "Player",
                column: "WarriorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Player_WarriorId",
                table: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_Player_WarriorId",
                table: "Player",
                column: "WarriorId",
                unique: true,
                filter: "[WarriorId] IS NOT NULL");
        }
    }
}
