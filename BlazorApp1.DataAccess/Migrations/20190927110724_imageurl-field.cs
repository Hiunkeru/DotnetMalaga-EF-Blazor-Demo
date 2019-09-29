using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.DataAccess.Migrations
{
    public partial class imageurlfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Warrior",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Warrior");
        }
    }
}
