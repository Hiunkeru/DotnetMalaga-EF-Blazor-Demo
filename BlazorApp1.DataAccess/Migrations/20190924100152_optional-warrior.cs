using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.DataAccess.Migrations
{
    public partial class optionalwarrior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Warrior_WarriorId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_WarriorId",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "WarriorId",
                table: "Player",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Player_WarriorId",
                table: "Player",
                column: "WarriorId",
                unique: true,
                filter: "[WarriorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Warrior_WarriorId",
                table: "Player",
                column: "WarriorId",
                principalTable: "Warrior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Warrior_WarriorId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_WarriorId",
                table: "Player");

            migrationBuilder.AlterColumn<int>(
                name: "WarriorId",
                table: "Player",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_WarriorId",
                table: "Player",
                column: "WarriorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Warrior_WarriorId",
                table: "Player",
                column: "WarriorId",
                principalTable: "Warrior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
